using PostgresTraining.V1.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostgresTraining.V1.Infrastructure
{
    [Table("persons", Schema = "dbo")]
    public class PersonEntity
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("first_name", TypeName = "varchar")]
        [MaxLength(45)]
        public string FirstName { get; set; }

        [Column("middle_name", TypeName = "varchar")]
        [MaxLength(45)]
        public string MiddleName { get; set; }

        [Column("surname", TypeName = "varchar")]
        [MaxLength(45)]
        public string Surname { get; set; }

        [Column("title")]
        public Title Title { get; set; }

        [Column("place_of_birth", TypeName = "varchar")]
        [MaxLength(45)]
        public string PlaceOfBirth { get; set; }

        [Column("date_of_birth", TypeName = "timestamp")]
        public DateTime? DateOfBirth { get; set; }
    }
}
