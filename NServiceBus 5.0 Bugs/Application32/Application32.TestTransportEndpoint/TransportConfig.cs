﻿//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by ServiceMatrix.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using NServiceBus;
 
namespace Application32.TestTransportEndpoint
{
	public class TransportConfig : INeedInitialization
	{
		public void Customize(BusConfiguration config)
		{
			config.UseTransport<NServiceBus.RabbitMQTransport>();
		}
	}
}
