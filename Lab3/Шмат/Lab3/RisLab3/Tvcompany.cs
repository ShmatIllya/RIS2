using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace RisLab3 {
    [DataContract]
    class Tvcompany {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public double Price { get; set; }

        public Tvcompany(int id, string name, string country, double price) {
            this.Id = id;
            this.Name = name;
            this.Country = country;
            this.Price = price;
        }

        public Tvcompany() {
            this.Id = 0;
            this.Name = "";
            this.Country = "";
            this.Price = 0;
        }
    }
}
