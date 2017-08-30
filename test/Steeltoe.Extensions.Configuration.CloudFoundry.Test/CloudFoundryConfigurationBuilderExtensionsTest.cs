﻿//
// Copyright 2015 the original author or authors.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Steeltoe.Extensions.Configuration.CloudFoundry.Test
{
    public class CloudFoundryConfigurationBuilderExtensionsTest
    {
        [Fact]
        public void AddCloudFoundry_ThrowsIfConfigBuilderNull()
        {
            // Arrange
            IConfigurationBuilder configurationBuilder = null;

            // Act and Assert
            var ex = Assert.Throws<ArgumentNullException>(() => CloudFoundryConfigurationBuilderExtensions.AddCloudFoundry(configurationBuilder));
            Assert.Contains(nameof(configurationBuilder), ex.Message);

            var ex2 = Assert.Throws<ArgumentNullException>(() => CloudFoundryConfigurationBuilderExtensions.AddCloudFoundry(configurationBuilder, null));
            Assert.Contains(nameof(configurationBuilder), ex2.Message);
        }

        [Fact]
        public void AddCloudFoundry_AddsCloudFoundrySourceToSourcesList()
        {
            // Arrange
            var configurationBuilder = new ConfigurationBuilder();

            // Act and Assert
            configurationBuilder.AddCloudFoundry();

            CloudFoundryConfigurationSource cloudSource = null;
            foreach (var source in configurationBuilder.Sources)
            {
                cloudSource = source as CloudFoundryConfigurationSource;
                if (cloudSource != null)
                    break;
            }
            Assert.NotNull(cloudSource);
        }
    }
}
