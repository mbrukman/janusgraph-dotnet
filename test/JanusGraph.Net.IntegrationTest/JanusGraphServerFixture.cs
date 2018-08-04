﻿#region License

/*
 * Copyright 2018 JanusGraph Authors
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#endregion

using System.Threading.Tasks;
using TestContainers.Core.Builders;
using Xunit;

namespace JanusGraph.Net.IntegrationTest
{
    public class JanusGraphServerFixture : IAsyncLifetime
    {
        private readonly GremlinServerContainer _container = new GenericContainerBuilder<GremlinServerContainer>()
            .Begin().WithImage("florianhockmann/janusgraph-testing:latest").WithExposedPorts(8182).Build();

        public string Host => _container.Host;
        public int Port => _container.Port;

        public Task InitializeAsync()
        {
            return _container.Start();
        }

        public Task DisposeAsync()
        {
            return _container.Stop();
        }
    }
}