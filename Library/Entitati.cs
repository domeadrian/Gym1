using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{

    [Table("dbo.Client")]
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdClient { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }

        public int IdSala { get; set; }
        public string IdUtilizator { get; set; }
        public bool? Sters { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public DateTime DataCreare { get; set; }

        IList<Abonament> _abonamentList = null;
        public virtual IList<Abonament> AbonamentList
        {
            get { return _abonamentList ?? (_abonamentList = new List<Abonament>()); }
            private set { _abonamentList = value; }
        }

    }

    [Table("dbo.Angajat")]
    public partial class Angajat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAngajat { get; set; }
        public int Salariu { get; set; }
        public System.DateTime DataAngajare { get; set; }

        //tip angajat
    }

    [Table("dbo.Abonament")]
    public partial class Abonament
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAbonament { get; set; }
        public int IdClient { get; set; }
        public string TipAbonament { get; set; }
        public int Pret { get; set; }
        public System.DateTime DataInceput { get; set; }
        public System.DateTime DataFinalizare { get; set; }


        [ForeignKey("IdClient")]
        public virtual Client Client { get; set; }
    }

    [Table("dbo.Sala")]
    public partial class Sala
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSala { get; set; }
        public string AdresaSala { get; set; }
        public System.TimeSpan OraDeschidere { get; set; }
        public System.TimeSpan OraInchidere { get; set; }
    }

    [Table("Nomenclator.TipAngajat")]
    public partial class TipAngajat
    {
        [Key]
        public int Id { get; set; }
        public string Nume { get; set; }
    }

    [Table("dbo.Review")]
    public partial class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdReview { get; set; }
        public int IdUtilizator { get; set; }
        public string Comentariu { get; set; }
        public int Rating { get; set; }
    }
}
