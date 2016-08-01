using System.Linq;
using System.Threading.Tasks;
using IngswDev.EntityFramework.Managers.Scopes;
using IngswDev.Models;
using Microsoft.AspNetCore.Mvc;

namespace IngswDev.Components
{
    [ViewComponent(Name = "HighLights")]
    public class HighLightsComponent : ViewComponent
    {
        private readonly IEventManager _eventManager;

        public HighLightsComponent(IEventManager eventManager)
        {
            _eventManager = eventManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var events = await _eventManager.HighlightsAsync(new PagingViewModel(0, 10));
            return View("~/Views/Shared/Components/_HighLightsEvents.cshtml", events);
        }
    }
}
