using Newtonsoft.Json;
using System.Collections.Generic;

namespace HX.GenerateCode.Model
{
    public class ClientRequest
    {
        public int SponsorId { get; set; }
        public string ProcedureName { get; set; }

        public List<Request> Parameters { get; set; }
    }
}