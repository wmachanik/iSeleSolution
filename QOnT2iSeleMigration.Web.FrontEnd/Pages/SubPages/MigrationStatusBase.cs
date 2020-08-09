using Microsoft.AspNetCore.Components;
using QOnT2iSeleMigration.Web.FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QOnT2iSeleMigration.Web.FrontEnd.Pages.SubPages
{
    public class MigrationStatusBase : ComponentBase
    {
        
        [Parameter]
        public MigrationStatusClass MigrationStati { get; set; }

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        [Parameter]
        public EventCallback OnStatiChange {get ; set;}

        public async Task UpdateMigrationStati()
        {
            await OnStatiChange.InvokeAsync(MigrationStati);
        }
    }
}
