﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AB.Middleware.SampleApp.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ScopedClass _scoped;
        private readonly TransientClass _transient;
        private readonly SingletonClass _singleton;
        private readonly ICorrelationContextAccessor _correlationContext;
        private readonly IClientIdContextAccessor _clientIdAccessor;

        public ValuesController(ScopedClass scoped, TransientClass transient, SingletonClass singleton,
            ICorrelationContextAccessor correlationContext, IClientIdContextAccessor clientIdAccessor)
        {
            _scoped = scoped;
            _transient = transient;
            _singleton = singleton;
            _correlationContext = correlationContext;
            _clientIdAccessor = clientIdAccessor;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var correlation = _correlationContext.CorrelationContext.CorrelationId;

            return new[]
            {
                $"DirectAccessor={correlation}",
                $"Transient={_transient.GetCorrelationFromScoped}",
                $"Scoped={_scoped.GetCorrelationFromScoped}",
                $"Singleton={_singleton.GetCorrelationFromScoped}",
                $"TraceIdentifier={HttpContext.TraceIdentifier}",
                $"ClientId={_clientIdAccessor.ClientContext.ClientApplicationId}"
            };
        }
    }
}
