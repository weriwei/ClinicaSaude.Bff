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
            SELECT *, (SELECT date from schedules WHERE id = id_schedule) 
            FROM appointment WHERE id_patient = @Id_Patient";
    }
}
