using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgStore
{
    class StaffManager
    {
        List<Moderator> moderators;
        List<Administrator> administrators;
        StaffManager staffManager;

        private StaffManager() { }

        public StaffManager Instance() {
            if (staffManager == null)
                staffManager=new StaffManager();
           
                return staffManager;
        }

        public Administrator CreateAdministrator() { return new Administrator(); }
        public Moderator CreateModerator() { return new Moderator(); }


    }
}
