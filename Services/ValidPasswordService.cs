using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ValidPasswordService : IValidPasswordService
    {
        public int scoreStrenghPassword(string password)
        {

            return Zxcvbn.Core.EvaluatePassword(password).Score;

        }

    }
}
