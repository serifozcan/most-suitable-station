---
services: functions
platforms: dotnet
author: serifozcan
---
# Most suitable (with most power) link station
Solves the most suitable (with most power) link station for a device at given point [x,y].

## Prerequisites

1. Visual Studio, either:
   - Visual Studio 2017 Update 3 with the Azure workload installed (Windows)
   - Visual Studio Code with the [C# extension](https://code.visualstudio.com/docs/languages/csharp) (Windows)
1. [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli?view=azure-cli-latest)

## Deployment
[![Deploy to Azure](http://azuredeploy.net/deploybutton.svg)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fserifozcan%2Fmost-suitable-station%2Fmaster%2FAzureDeploy%2Fazuredeyloy.json)

## Runing the Tests
Run all the tests in the `MostSuitableStation.Tests` project via Visual Studio.

## Run the project
1. Compile and run:

    - Clone the repository, open the project in Visual studio, just press F5 to compile and run **MostSuitableStation.sln**.

    You should see output similar to the following:

    ```
    Http Functions:

            MostSuitableStation: http://localhost:7071/api/most-suitable-station

    Debugger listening on [::]:5858
    ```
## Run

- To run manually, send an HTTP request using Postman or CURL:

    `POST http://localhost:7071/api/most-suitable-station`

    Body: 
    ```json
      {
        "point": { "x": 0 , "y": 0 },
        "stations": [{
          "coordinates": { "x": 0 , "y": 0 },
          "reach": 10
        },
      {
          "coordinates": { "x": 20 , "y": 20 },
          "reach": 5
        },
        {
          "coordinates": { "x": 10 , "y": 0 },
          "reach": 12
        }]
      }
    ```
