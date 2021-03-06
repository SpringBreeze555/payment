﻿using Essensoft.AspNetCore.Payment.WeChatPay;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Http;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddWeChatPay(this IServiceCollection services)
        {
            services.AddHttpClient(nameof(WeChatPayClient));

            services.TryAddEnumerable(ServiceDescriptor.Singleton<IHttpMessageHandlerBuilderFilter, WeChatPayHandlerBuilderFilter>());

            services.AddSingleton<WeChatPayCertificateManager>();
            services.AddSingleton<IWeChatPayClient, WeChatPayClient>();

#if NETCOREAPP3_1
            services.AddSingleton<IWeChatPayNotifyClient, WeChatPayNotifyClient>();
#endif
        }
    }
}