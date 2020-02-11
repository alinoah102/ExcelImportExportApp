using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models {
    public class SidebarViewModel {
        public Tab ActiveTab { get; set; }
    }

    public enum Tab {
        Home,
        ImportData,
        Logout
    }
}
