using MediatR;
using MediatrDemo.CoreLib.Models;
using MediatrDemo.CoreLib.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatrUi.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<PersonalModel> People;
        IMediator _mediator;
        public IndexModel(ILogger<IndexModel> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task OnGet()
        {
            People = await _mediator.Send(new GetPeopleQuery());
        }
    }
}
