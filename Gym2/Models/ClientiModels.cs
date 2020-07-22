using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym2.Models
{
    public class ClientiIndexModel
    {
        public List<ClientItem> ClientItems { get; set; }

        public class ClientItem
        {
            public string Nume { get; set; }
            public string Prenume { get; set; }
            public int IdClient { get; set; }
            public string IdUtilizator { get; set; }
            public int IdSala { get; set; }

            public bool AreAbonamentCurent { get; set; }

        }
    }

    public class ClientEditViewModel
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public int IdClient { get; set; }
        public string IdUtilizator { get; set; }
        public int IdSala { get; set; }


    }

}



