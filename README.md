# Energy Explorer

An information visualization application developed as for the inf-viz course (TNM048) at Linköpings University 2009 by Fredrik Rinman, Petter Grundström & Tobias Lundin.

The goal was to create a tool that enables exploratory analysis into how energy consumption and welfare are connected for a given country.

 
## Visualization methods
To help visual analytics the app uses several methods and the software was developed using the GeoAnalytics Visualization (GAV) framework.
[More methods at NComVA's guides](http://www.ncomva.se/guide/?chapter=Visualizations)

### Cloropleth Map
![Cloropleth Map][cloropleth-img]
### Scatter Plot
![Scatter Plot][scatterplot-img]
### Parallel Coordinates Plot
![Parallel Coordinates Plot][pcplot-img]
### Table Lens
![Table Lens][tablelens-img]

## Data sources
The following data points was collected from public databases provided by the United Nations and the World Bank in the time segment 1990-2005.

#### Welfare variables
* Employment-to-population ratio, percentage
* Infant mortality rate (0-1 year) per 1,000 live births
* Personal computers per 100 population
* Internet users per 100 population
* Exports of goods and services (% of GDP)
* Imports of goods and services (% of GDP)
* GDP per capita, current international dollars
* GDP growth (annual %)
* Percentage urban (%)
* Population, total

#### Energy variables
* Energy use (kg of oil equivalent per capita)
* Electric power consumption (kWh per capita)
* Greenhouse Gas (GHGs) Emissions without LULUCF, in Gigagrams (Gg) CO2 equivalent

[Cloropleth-img]: \docs\images\component_map.png
[scatterplot-img]: \docs\images\component_map.png
[pcplot-img]: \docs\images\component_map.png
[tablelens-img]: \docs\images\component_map.png