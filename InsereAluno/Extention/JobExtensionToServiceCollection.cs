using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsereAluno.Extention
{
    public static class JobExtensionToServiceCollection
    {
        public static void AddJobs(this IServiceCollection services)
        {
            services.AddHostedService<NomesJob>(_ => new NomesJob(20000));
           
        }
    }
}
