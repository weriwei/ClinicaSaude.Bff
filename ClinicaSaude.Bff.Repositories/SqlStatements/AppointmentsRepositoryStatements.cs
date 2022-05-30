namespace ClinicaSaude.Bff.Repositories.SqlStatements
{
    public static class AppointmentsRepositoryStatements
    {
        public const string INSERT_APPOINTMENT = @"
            INSERT INTO appointment
            (
                id_schedule,
                id_patient,
                status
            )
            VALUES (@Id_Schedule, @Id_Patient, @Status)";

        public const string GET_APPOINTMENTS_BY_PATIENT_ID = @"
            SELECT appointment.status, doctor.name, schedules.date,
                (SELECT name from speciality join relationship_doctor_speciality as rds on speciality.id = rds.id_speciality WHERE rds.id_doctor = doctor.id) AS speciality FROM appointment 
                JOIN schedules on schedules.id = appointment.id_schedule 
                JOIN doctor on doctor.id = schedules.id_doctor 
                WHERE appointment.id_patient = @Id_Patient";
    }
}
