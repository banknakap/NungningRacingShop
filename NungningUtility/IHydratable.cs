using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NungningUtility
{
    public interface IHydratable
    {
        int KeyID { get; set; }

        void Fill(IDataReader dr);
    }
}
