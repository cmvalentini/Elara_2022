using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.BackRestore;

namespace BLL.BackRestore
{
    public class BackRestoreBLL
    {
        public void RealizarBackUp(BE.BackRestore.BackRestore br)
        {
            DAL.BackRestore.BackRestoreDAL BRDAL = new DAL.BackRestore.BackRestoreDAL();

            BRDAL.RealizarBackUp(br);

        }

        public BE.BackRestore.BackRestore RealizarRestore(BE.BackRestore.BackRestore restoreBe)
        {
             
            DAL.BackRestore.BackRestoreDAL brdal = new DAL.BackRestore.BackRestoreDAL();
            restoreBe = brdal.RealizarRestore(restoreBe);

            return restoreBe;

        }
    }
}
