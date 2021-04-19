# Medical Management Application

## About The Project

### Terms of Development

| Platform | GUI | Timeframe | Database Solution | Comunication Terms |
|----|----|----|----|----|
| Windows | WPF | 01.March.2021-09.May.2021 | Simple _.csv_ file storage | Notify client after each feature implementation

**Features**
- **Journals**
  - create journal - _The ability to raise new journals_
  - Save Journal - _The ability to save journals in the form of persistant data_
  - Update Journal - _The ability to update the data of exsisting journals_
  - Delete Journal - _The ability to delete existing journals_
  - Search for Journal - _The ability to search for a specific Journal based on a patients Social Security Number (SSN)_
  - Populate a Journal - _The ability to populate a Journal based on a Patients Social Security Number (SSN)_
  - To PDF - _If possible, within the given timeframe, the client would like to have a feature for printing a journal to PDF_
- **Patients**
  - Search for Patient - _The ability to look up a patient based on their Social Security Number (SSN)_
  - Readonly - _Can only be accessed, not created, updated, deleted or in any other way manipulated_

**Notes**
- Pregnancy Journal - _Will only be filled out once, when the journal is created_
- Traveling Journal - _Will be updated regularly_
- UI - _An agreement has been formed to have the UI be somehting that is regulated as we go, becaue there's no specifications regarding the layout of the UI._

## The program
**Goal**
> To form the least viable product (LVP)

**Input**
> User Interaction

**Output**
> Graphical User interface

## Code Practice
 - **Structs/Classes**
   - Form a `struct` if an `interface` category has four or more properties
   - Form a `class` if the above applies as well as if the object would consist of a larger structure
   - `Fields` are always private
   - `Properties` are always public
 - **Interfaces**
   - `Interfaces` are suffixed with 'I' and nothing else
   - `Interfaces` must have their own subfolder, which should never be included in their `namespace`
 - **Methods**
   - `Method` parameters are suffixed with an '_'
 - **Global**
   - `Scopes` must have explicit enclosure 
 - **ProjectStructure**
   - **Layers**
     - UI - All user integration (_API, GUI etc._)
     - Gateway - Connection to Business layer, databases, LAMP etc.
     - Business - All logic and direct behavior related to the core application

See the [Wiki](./WikiPages/Front.md) for more in depth information about the project.

## Versioning
The Assignment specifies that versioning should be done according to the following template: [_Major_].[_Minor_].[_Patch_].
- **Major:**
  - Major Changes
  - Changes to Core structure (_Like an UI Switch_)
- **Minor:**
  - Features
  - Large Code Refactoring (_Ex. If you create a new file when refactoring_)
- **Patch:**
  - Hotfixs
  - Revisions
  - Minor Code Refactoring

Each `Feature` must be branched out and developed on an isolated branch and merged back into the `Developer` branch when done.
The syntax for the structure of folders must be presented as: [DeveloperName]/[Version]/[BranchName], where as branches should be named as follows: [*Root*]-[*Feature*]_[*SubFeature*].\
**Example:**
>**Folder Structure:** _Oiski/v1_ \
>**Branch Name:** _MMA-Interface_MainMenu_ \
>**Full Path:** _Oiski/v1/MMA-Interface_MainMenu_

## Namespaces
Namespaces are bould from root and extended to branch out into different areas from there.
The core structure is as follows: [_Firm_].[_Project_].[_Folder_]. \
**Example**
>**Firm:** _NOP_ \
>**Project:** _MMA_ \
>**Folder:** _Repository_ \
>**Namespace:** _NOP.MMA.Repository_

### Change Log
- **[v0.1.0](https://github.com/NOP-Nullified-Objective-Phantoms/NOP.MMA/releases/tag/v0.1.0)**
  - Implemented `Debug` class
  - Added WiKiFront
  - Added `Debug` class to WiKi
- **[v0.2.0](https://github.com/NOP-Nullified-Objective-Phantoms/NOP.MMA/releases/tag/v0.2.0)**
  - Implemented `Patient` Class
  - Changes to `IPatient` interface
    - Summaries for `IPatient`, `IPatientData` and `IPatientSocialData`
  - Imported NOP.Common Library
    - Added DLLs folder and added it to .gitignore. (_You must import the library locally, in the same folder, yourself as well_)
  - Implemented `Patient` class
    - Inherits from IPatient
    - Default constructor where an ID can be provided. And ID will be generated if one is not provided
  - Implemented `PatientFactory` class
    - Ability to create `IPatient` objects without incrementing the counter
    - Ability to create empty `IPatient` objects
- **[v0.3.0](https://github.com/NOP-Nullified-Objective-Phantoms/NOP.MMA/releases/tag/v0.3.0)**
  - Revision to `Patient`
    - Fixed patient counter
    - Summary for `AllergyAssessement` struct
    - Summary for `ChronicMedicalHistory` struct
  - Added documentation for various interfaces related to journals
  - Added documentation for various structs related to journals
  - Revision to history data
    - Added indexer property
    - Ability to add/remove history entries from interface layer
  - Revision to journal related data objects
    - Added `Anamnese` class
    - Added `Investigation` class
    - Added `Journal` class
    - Added `RRAssessement` class
    - Added `AbortionHistory` class
    - Added `PregnancyHistory` class
    - Added `PregnancyHistoryEntry` class
    - Added `AbortionHistoryEntry` class
  - Revision to journal related interfaces
    - Opened struct properties in `IAnamnese` interface
    - Opened struct properties in `IInvestigation` interface
    - Corrected a spelling mistake in `IPregnancyJournal` interface
    - Corrected a spelling mistake in `IResourcesAndRiskAssessement` interface
  - Revision to journal related structs
    - Closed `FertilityTreatmentData` properties and added constrcutor instead
    - Closed `MenstrualCycle` properties and added constrcutor instead
    - Closed `PrenatakRiskAssessement` properties and added constrcutor instead
    - Closed `MenstrualCycle` properties and added constrcutor instead
    - Closed `Screening` properties and added constrcutor instead
    - Closed `TermData` properties and added constrcutor instead
    - Changed `WorkEnvironmentEffect` to a class instead og a struct, and added constructor
    - Added a NotSet flag for `WorkEnvironment` enum
    - Corrected spelling mistake in `RRAssessement`
  - Revision to patient releated structs
    - Fixed wrong interface implementation for `AbortionHistoryEntry`
    - Closed `AlcoholHistory` properties and added constructor instead
    - Closed `AllergyAssessement` properties and added constructor instead
    - Closed `ChronicMedicalHistory` properties and added constructor instead
    - Closed `TobaccoHistory` properties and added constructor instead
  - Implemented Journal
    - `Journal` class as a base
    - `PregnancyJournal` class, which inherits from `Journal`
  - Implemented `JournalFactory` class
    - Revision to `Patient` and `PatientFactory`
  - Revision to journal related classes
    - Changed `Journal` constrcutor to take in a nullable int.
    - Added Seperator constants to `PregnancyJournal` class
  - Implemented `PregnancyJournalRepo` class
    - Added `JournalRepo` class, as a base for Journal Repositories
- [v0.4.0](https://github.com/NOP-Nullified-Objective-Phantoms/NOP.MMA/releases/tag/v0.4.0)
  - Added constructor to `Journal` Releated structs
  - Fixed various mistakes in `PregnancyJournal` releated objects
  - Added `TravelerJournal` Class
  - Fixed missing property in build and save for `UltrasoundResult` in `TravelerJournal`
  - Changed how the `JournalRepo` base class behaves regarding `IRepository` implementation
    - `JournalRepo` now implements the `IRepository` interface
    - `PregnancyJournalRepo` now overrides the `JournalRepo` base `IRepository` methods
  - Implemented `TravelerJournalRepo`
    - Extended `JournalFactory` to include `TravelerJournal` class
    - Finalized `TravelerJournal` specific objects
- **[v0.5.0](https://github.com/NOP-Nullified-Objective-Phantoms/NOP.MMA/releases/tag/v0.5.0)**
  - Created Unit Test Project
    - Created Tests for `PatientFactory` (_All Passed_)
    - Added Tests for `PregnancyJournal` (_All Passed_)
    - Added Tests for `PatientRepo` (_All Passed_)
  - Implemented Helpers
    - Added `PatientData` Class
    - Added `PatientSocialData` class
    - Added `PatientHelper` class
      - Added ability to create new patients from the `PatientHelper`
    - Added `AssertHelper` class
  - Revision
    - Fixed `Anamnese` not being opened
    - Fixed `Investigation` not being opened
    - Fixed `Patient` Default ID being 0, instead of the correct ID of 1
    - Fixed `PatientFactory` ID Index not being assigned as intended
    - Fixed an issue where the `Debug` class couldn't find a path to its associated file
    - Fixed a crash when a `Patient` got passed a null factor when building
    - Fixed several missing properties assignments upon build in `PregnancyJournal`
    - Fixed ID's not developing as expected in `PatientFactoryTests`
    - Fixed `PatientRepo` not being able to form a fully qualified path to its associated file
    - Fixed attempts to build patients from an empty string in `PatientRepo`
    - Fixed wrong log file name in `Debug` class 
    - Added `FileName` property to the `PatientRepo` and changed `StoragePath` property to only point to the storage folder instead of the storage file
    - Implemented log file debugging in `PatientRepo`
- **[0.6.0](https://github.com/NOP-Nullified-Objective-Phantoms/NOP.MMA/releases/tag/v0.6.0)**
  - Extended Unit Test Project
    - Implemented Unit Tests for `TravelerJournal` in the `JournalFactoryTests` (_All Passed_)
    - Implemented Unit Tests for `PregnancyJournalRepo` (_All Passed_)
    - Implemented Unit Tests for `TravelerJournalRepo` (_All Passed_)
  - Implemented Helpers
    - Added `JournalHelper` class
    - Added the ability for `JournalHelper` to include manually storage of `TravelerJournal` objects as well
  - Revision
    - Fixed NULL values in `Anamnese`
    - Fixed NULL values in `PregnancyJournal`
    - Fixed NULL value in `AbortionHistory`
    - Fixed NULL value in `PregnancyHistory`
    - Fixed bad timestamp for `Debug` entries
    - Fixed an issue where the `PregnancyJournalRepo` couldn't generate a fully qualified path to it's storage folder
    - Fixed a false positive in `PatientRepoTests`
    - Fixed a false positive in `PregnancyJournalRepoTests`
    - Added exception handling to `JournalRepo` class
    - Added exception handling to `PatientRepo` class
    - Added exception handling to `PregnancyJournalRepo`
    - Added exception handling to `TravelerJournal`
    - Added exception handling to `TravelerJournalRepo`
-  **[v]()**
   - Implemented Tab System
     - Added `ITabCollection` interface
     - Added `ITabItem` interface
     - Added `ITabItem<T>` interface
     - Added `NavTabPanel` class
     - Added `TabCollection` class
     - Added `PatientDataTab` class
     - Added `TabItem` class
   - Implemented View Models
     - Added `PregnancyJournalViewModel`
     - Added `TravelerJournalViewModel`
     - Added sample code in MainWindow` class
     - Added GUI setup for the base layout (_**NOTE:** Legacy code included_)
   - Revision
     - Fixed comma crash when building a `Patient` from storage
     - Fixed wrong path when setting storage path in `PregnancyJournalRepo` and `TravelerJournalRepo`