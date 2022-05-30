namespace ClinicaSaude.Bff.Repositories.SqlStatements
{
    public static class DoctorRepositoryStatements
    {
        public const string GET_DOCTOR_BY_SPECIALITY_ID = @"
            SELECT *,(SELECT name from speciality where id = @Id) as Speciality_Name from doctor 
                join relationship_doctor_speciality as rds on doctor.id = rds.id_doctor 
                where rds.id_speciality = @Id";

        public const string GET_DOCTOR_SCHEDULES_BY_DOCTOR_ID = @"SELECT * from schedules WHERE id_doctor = @Id";

        public const string GET_SCHEDULES_AVAILABLE_BY_DOCTOR_ID = @"
            SELECT * FROM schedules 
                WHERE id NOT IN (SELECT id_schedule FROM appointment) AND schedules.id_doctor = @Id";
    }
}
