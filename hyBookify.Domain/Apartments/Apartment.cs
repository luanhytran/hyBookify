using hyBookify.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace hyBookify.Domain.Apartments
{
    public sealed class Apartment : Entity
    {
        public Apartment(Guid id) : base(id) { }

        public Name Name { get; set; }

        public Description Description { get; private set; }

        public Address Address { get; private set; }
        public Email Email { get; private set; }
    }
}
