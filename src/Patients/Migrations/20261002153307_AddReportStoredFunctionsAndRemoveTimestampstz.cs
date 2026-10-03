using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patients.Migrations
{
    /// <inheritdoc />
    public partial class AddReportStoredFunctionsAndRemoveTimestampstz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "chk_users_role",
                table: "users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "examination_date",
                table: "examinations",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamptz");

            migrationBuilder.AlterColumn<DateTime>(
                name: "appointment_date",
                table: "appointments",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamptz");

            migrationBuilder.AddCheckConstraint(
                name: "chk_users_role",
                table: "users",
                sql: "\"role\" IN ('Registrator', 'Doctor', 'ChiefDoctor')");

            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION get_doctor_workload_report(p_start_date TIMESTAMP, p_end_date TIMESTAMP)
             RETURNS TABLE(doctor_id integer, doctor_name text, specialty_title text, total_appointments bigint, completed_appointments bigint, cancelled_appointments bigint, prescriptions_count bigint)
             LANGUAGE plpgsql
            AS $$
            BEGIN
                RETURN QUERY
                SELECT
                    d.id AS doctor_id,
                    (u.last_name || ' ' || u.first_name || COALESCE(' ' || u.middle_name, ''))::TEXT AS doctor_name,
                    COALESCE(s.title, 'Не указана')::TEXT AS specialty_title,
                    COUNT(DISTINCT a.id) AS total_appointments,
                    COUNT(DISTINCT a.id) FILTER (WHERE a.status = 'Completed') AS completed_appointments,
                    COUNT(DISTINCT a.id) FILTER (WHERE a.status = 'Cancelled') AS cancelled_appointments,
                    COUNT(p.id) AS prescriptions_count
                FROM doctors d
                JOIN users u ON d.user_id = u.id
                LEFT JOIN specialties s ON d.specialty_id = s.id
                LEFT JOIN appointments a ON d.id = a.doctor_id AND a.appointment_date BETWEEN p_start_date AND p_end_date
                LEFT JOIN examinations e ON a.id = e.appointment_id
                LEFT JOIN prescriptions p ON e.id = p.examination_id
                GROUP BY d.id, u.last_name, u.first_name, u.middle_name, s.title
                ORDER BY completed_appointments DESC;
            END;
            $$;

                CREATE OR REPLACE FUNCTION get_top_diagnoses_report(p_start_date TIMESTAMP, p_end_date TIMESTAMP, p_limit INTEGER)
             RETURNS TABLE(diagnosis text, cases_count bigint, percentage numeric)
             LANGUAGE plpgsql
            AS $$
                BEGIN
                    RETURN QUERY
                    WITH diag_counts AS (
                        SELECT
                            TRIM(UPPER(e.diagnosis)) AS diag,
                            COUNT(*) AS cnt
                        FROM examinations e
                        WHERE e.examination_date BETWEEN p_start_date AND p_end_date
                        GROUP BY TRIM(UPPER(e.diagnosis))
                    ),
                    total AS (
                        SELECT SUM(cnt) AS total_cnt FROM diag_counts
                    )
                    SELECT
                        dc.diag::TEXT AS diagnosis,
                        dc.cnt AS cases_count,
                        ROUND((dc.cnt * 100.0 / NULLIF(t.total_cnt, 0)), 2) AS percentage
                    FROM diag_counts dc, total t
                    ORDER BY dc.cnt DESC, dc.diag ASC
                    LIMIT p_limit;
                END;
                $$;

                CREATE OR REPLACE FUNCTION get_prescriptions_by_specialty_report(p_start_date TIMESTAMP, p_end_date TIMESTAMP)
             RETURNS TABLE(specialty_title text, medication_name text, prescriptions_count bigint)
             LANGUAGE plpgsql
            AS $$
                BEGIN
                    RETURN QUERY
                    SELECT
                        s.title::TEXT AS specialty_title,
                        p.medication_name::TEXT AS medication_name,
                        COUNT(p.id) AS prescriptions_count
                    FROM prescriptions p
                    JOIN examinations e ON p.examination_id = e.id
                    JOIN appointments a ON e.appointment_id = a.id
                    JOIN doctors d ON a.doctor_id = d.id
                    LEFT JOIN specialties s ON d.specialty_id = s.id
                    WHERE e.examination_date BETWEEN p_start_date AND p_end_date
                    GROUP BY s.title, p.medication_name
                    ORDER BY prescriptions_count DESC, s.title;
                END;
                $$;
            

                CREATE OR REPLACE FUNCTION get_examination_registry_report(p_start_date TIMESTAMP, p_end_date TIMESTAMP)
             RETURNS TABLE(examination_id integer, examination_date TIMESTAMP, patient_card text, patient_name text, doctor_name text, diagnosis text, has_prescriptions boolean, has_referrals boolean)
             LANGUAGE plpgsql
            AS $$
                BEGIN
                    RETURN QUERY
                    SELECT
                        e.id AS examination_id,
                        e.examination_date,
                        pat.card_number::TEXT AS patient_card,
                        (pat.last_name || ' ' || pat.first_name || COALESCE(' ' || pat.middle_name, ''))::TEXT AS patient_name,
                        (doc_u.last_name || ' ' || doc_u.first_name || COALESCE(' ' || doc_u.middle_name, ''))::TEXT AS doctor_name,
                        e.diagnosis::TEXT,
                        EXISTS(SELECT 1 FROM prescriptions pr WHERE pr.examination_id = e.id) AS has_prescriptions,
                        EXISTS(SELECT 1 FROM referrals rf WHERE rf.examination_id = e.id) AS has_referrals
                    FROM examinations e
                    JOIN appointments a ON e.appointment_id = a.id
                    JOIN patients pat ON a.patient_id = pat.id
                    JOIN doctors doc ON a.doctor_id = doc.id
                    JOIN users doc_u ON doc.user_id = doc_u.id
                    WHERE e.examination_date BETWEEN p_start_date AND p_end_date
                    ORDER BY e.examination_date DESC;
                END;
                $$;
            """);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "chk_users_role",
                table: "users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "examination_date",
                table: "examinations",
                type: "timestamptz",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "appointment_date",
                table: "appointments",
                type: "timestamptz",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AddCheckConstraint(
                name: "chk_users_role",
                table: "users",
                sql: "\"role\" IN ('Registrator', 'Doctor')");

            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS get_doctor_workload_report(TIMESTAMP, TIMESTAMP);
                DROP FUNCTION IF EXISTS get_top_diagnoses_report(TIMESTAMP, TIMESTAMP, INT);
                DROP FUNCTION IF EXISTS get_prescriptions_by_specialty_report(TIMESTAMP, TIMESTAMP);
                DROP FUNCTION IF EXISTS get_examination_registry_report(TIMESTAMP, TIMESTAMP);
            """);
        }
    }
}
