# Lattes Data Extraction API 🚀

## Overview 💡
The Lattes Data Extraction API is a .NET 6 application developed as part of a final degree project. This API streamlines the extraction, transformation, and loading (ETL) of academic research data from the [Lattes platform](https://lattes.cnpq.br/). By automating the ETL process, the API enables the organization and persistence of researcher data for future analysis and queries, eliminating the need for manual processing.

## Purpose 🎯
The primary goal of this project is to address the challenges of managing and analyzing large volumes of academic data extracted from the Lattes platform. By developing an API that processes XML files, performs ETL operations, and stores the data in a structured database, we aim to facilitate easy access and comprehensive analysis of academic researchers' information.

## Application's Execution Flow ![workflow_6751798](https://github.com/Raffael-Eloi/lattes-data-extraction-api/assets/51720161/032a356b-e39a-433c-80a1-707f27734975)
![Estudo](https://github.com/Raffael-Eloi/lattes-data-extraction-api/assets/51720161/cb80d108-a13f-4a5a-8c62-6b033b4db473)

## Key Features 🔑
- **Automated ETL Process:** Seamlessly extracts, transforms, and loads data from XML files.
- **TDD and BDD:** Utilizes Test-Driven Development (TDD) for robust unit testing and Behavior-Driven Development (BDD) with SpecFlow for integration tests.
- **SOLID Principles:** Ensures a well-structured and maintainable codebase by adhering to SOLID design principles.

## Technologies and Concepts 💻
- **.NET 7 API:** Modern and efficient API development.
- **ETL (Extract, Transform, Load):** Processes data from raw XML files to a structured database format.
- **Test-Driven Development (TDD):** Ensures code reliability through comprehensive unit tests.
- **Behavior-Driven Development (BDD):** Facilitates integration testing with SpecFlow.
- **SOLID Principles:** Promotes clean and maintainable code architecture.

## Entity model ![database_3895312](https://github.com/Raffael-Eloi/lattes-data-extraction-api/assets/51720161/ee38aefc-cc4a-41fc-b7c8-12e05178ebe9)
![image](https://github.com/Raffael-Eloi/lattes-data-extraction-api/assets/51720161/b79f007d-8e1a-4bd2-b68a-7aa8d1ee8179)

## Project Structure 📁

![Project Structure](https://github.com/Raffael-Eloi/lattes-data-extraction-api/assets/51720161/a118e19e-8a5c-417b-ae84-3286e9f3b735)

## Application Flow 🌀

![Data Flow](https://github.com/Raffael-Eloi/lattes-data-extraction-api/assets/51720161/d44d92b1-ed49-4471-af17-811759704ed9)

## Application Flow Explained 🌀
![Estudo (1)](https://github.com/Raffael-Eloi/lattes-data-extraction-api/assets/51720161/69a5c6e2-e284-4dcf-bee4-8db841c7d644)
The `IGetDataInformationFactory` gets the TAG and returns a service specified in extract information in that given context.

## How it works ⭐
![LattesAPIExtractionExample](https://github.com/Raffael-Eloi/lattes-data-extraction-api/assets/51720161/1ebe9a77-74c2-47e0-9147-18f66edb024c)

## Getting Started

### Prerequisites 🗹
- .NET 7 SDK

### Running the Project 💻
1. **Clone the Repository:**
   ```sh
   git clone https://github.com/Raffael-Eloi/lattes-data-extraction-api.git
   cd lattes-data-extraction-api
   ```

2. **Restore Dependencies:**
   ```sh
   dotnet restore
   ```

3. **Build the Project:**
   ```sh
   dotnet build
   ```

4. **Run the API:**
   ```sh
   cd LattesDataExtraction.API.EntryPoint
   dotnet run
   ```

5. **Access the API:** <br>
   Open your browser and navigate to `http://localhost:5068/swagger` to view the API documentation and test the endpoints.

## Usage
- **Upload XML File:**
  Use the `/LattesDataExtraction` endpoint to upload an XML file extracted from the Lattes platform.

## Conclusion ![concept_11063232](https://github.com/Raffael-Eloi/lattes-data-extraction-api/assets/51720161/d6bcedd1-9eba-4d3d-bdac-4b81b94a9b1c)
This project successfully achieved its objective by developing an API that automates the ETL process for academic data from the Lattes platform. By enabling easy data extraction, transformation, and persistence, the API provides a valuable tool for researchers to conduct comprehensive analyses and gain insightful information.
