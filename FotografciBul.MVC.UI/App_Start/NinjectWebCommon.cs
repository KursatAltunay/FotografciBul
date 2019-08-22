[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(FotografciBul.MVC.UI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(FotografciBul.MVC.UI.App_Start.NinjectWebCommon), "Stop")]

namespace FotografciBul.MVC.UI.App_Start
{
    using System;
    using System.Web;
    using FotografciBul.BLL.Abstract;
    using FotografciBul.BLL.Concrete;
    using FotografciBul.BLL.Ninject;
    using FotografciBul.DAL.Abstract;
    using FotografciBul.DAL.Concrete.EntityFramework;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IFotografciService>().To<FotografciService>();
            kernel.Bind<IKullaniciService>().To<KullaniciService>();
            kernel.Bind<IHizmetTipiService>().To<HizmetTipiService>();
            kernel.Bind<IRandevuTalebiService>().To<RandevuTalebiService>();
            kernel.Bind<IResimService>().To<ResimService>();

            kernel.Load<CustomDALModule>();
        }        
    }
}
