# Portable Ubiquitous Mobile App (PUMA)
GitHub: [https://github.com/CSU-RSF/PUMA](https://github.com/CSU-RSF/PUMA)

## Introduction
This is a cross-platform mobile application framework (for iOS and Android) built on Xamarin to facilitate rapid development of mobile applications with basic UI, database, and mapping components.

## Technology Stack
Key technologies/tools include:
* Visual Studio 2015 or Xamarin Studio, device simulators (development environment)
* Xamarin (cross-platform mobile application framework)
* Portable Class Library (for sharing platform-agnostic business logic)
* Xamarin.Forms (for shared code at the UI level)
* SQLIte and SQLite.Net PCL (simple, native database storage)

In addition to the documentation provided here, the following resources are quite helpful for rounding out knowledge of Xamarin and its components:
* [Xamarin Developer Guides](https://developer.xamarin.com/guides/) - The essentials of Xamarin development
* [Xamarin University](https://university.xamarin.com/) - Extensive Xamarin tutorials and examples
* [Xamarin Forms Guides](https://developer.xamarin.com/guides/#xamarin-forms) - Useful info for cross-platform development with Xamarin.Forms
* [Portable Class Libraries](https://developer.xamarin.com/guides/cross-platform/application_fundamentals/building_cross_platform_applications/part_3_-_setting_up_a_xamarin_cross_platform_solution/) - Brief introduction
* [SQLite.NET PCL](https://www.nuget.org/packages/sqlite-net-pcl/)

## Using PUMA
The following sections point to portions of the PUMA app that provide a template for use in applications spun off from this one. This application uses Colorado Wetlands to illustrate database connections, shared business logic, and UI components.

### Framework Orientation
* PUMA directory => Portable Class Library (PCL) containing all shared components
  * Assets => functions and methods related to database models
  * Models => definitions of SQLite database models
  * Properties => contains assembly info
  * Resources => local icons and image storage
  * Views => HTML and Xaml pages (with corresponding "code behind" files in C#)
* PUMA.iOS & PUMA.Droid => directories containing platform-specific code (minimal on purpose)
  * Note the SQLite database file definitions in PUMA.Droid > MainActivity.cs and PUMA.iOS > AppDelegate.cs

### Configuration
You'll need to change configuration tailored to your application
* Properties: in PUMA.iOS and PUMA.Droid, double-click on Properties and change the Application Name in the Android Manifest (PUMA.Droid) and iOS Application (PUMA.iOS)
* Pages & Buttons: in all Xaml and C# code behind files, you'll want to change the titles and text to verbiage that suites your application. If you're not sure where to find these definitions/declarations

### Pages and Navigation
The app starts in App.cs and loads the MainPage (Xaml with C# code behind) wrapped in a NavigationPage, as are all other pages. This allows for native navigation components supplied by iOS and Android. It will then provide you with automatic navigation at the top of each page.

Navigation to another page is trigger on a "Click" event on buttons defined in the Xaml files, those events linking back to the code behind and sending the user somewhere based on their selection. The following Xaml button (MainPage.xaml)...

```html
<Button Text="Introduction" Clicked="ToIntroduction"...
```

is linked to the following action in the code behind (MainPage.xaml.cs)

```csharp
public async void ToIntroduction(object sender, EventArgs e)
{
    await Navigation.PushAsync(new HTMLPage("Introduction.html"));
}
```

This event pushes the corresponding Introduction.html page onto the stack (and thus makes it visible). In a simulator, when you then go that page and you navigate "back", it takes the page back off the stack. This is essentially how navigation and pages work--when a button is clicked, 
an event is called and a page push on top of the viewing stack and popped back off when you go "back" or manually pop it off.

#### HTML Pages
This is an example of dynamic rendering of HTML pages, which are stored in the Views.HTML folder and rendered by HTMLPage.cs code. Any events triggering the loading of pages with simple, static HTML markup will be able to dynamically render the HTML if the file is referenced (as seen in MainPage.xaml.cs) and in the Views.HTML folder.

#### Page Types
The PUMA has several Xamarin Page types included as samples:
* Navigation Page - see intro to Pages and Navigation section
* HTML Page - see HTML Pages above
* Content Page - see Views.PumasPage.xaml and code behind file for an example of a Content Page with a ListView element.
* Tabbed Page - see Views.PumasDetailPage.cs
* Carousel Page - see Views.PumaImagesPage.xaml and code behind

#### Customizing Pages
To customize the app to fit your needs, you'll need to reconfigure page names and their references and database models and repositories. Start at MainPage.xaml button Text and Clicked properties. Once you've changed those, go to the MainPage.xaml.cs code behind and realign the functions names with the Click properties you just modified. Then you'll want to also rename the page it's navigating to and everything associated with it in the Xaml and C# code behind files for the page you're navigating to. 

### Images
In the PUMA PCL, the EmbeddedImageResourceExtension.cs file contains code that links the PCL to platform-specific image storage locations, allowing for platform independent image references (see the image references in MainPage.xaml.cs, such as the following background image reference)

```csharp
<Image Source="\{local:ImageResource PUMA.Resources.Images.background.png}"...
```

When trying to dynamically find image files associated with database records, if you want to store your image files locally, store them in the PCL in Resources.Images.[ModelName].ID[#],
where ModelName represents the model name of database table in which you're storing image references and ID[#] corresponds to the ID number of your database primary key (e.g. DB1, DB2, DB3). The following line of code, taken from the Thumbnail definition in Puma.cs, illustrates the dynamic image location construction based on the class name, Id of the image record, and the filename for a thumbnail:

```csharp
return ImageSource.FromResource(string.Format("PUMA.Resources.Images.{0}.ID{1}.thumbnail.jpg", this.GetType().Name, Id));
```

This image lookup construction can be customized if so desired, but it provides a basic pattern for image storage and lookup.

Note that when files are stored locally (in the app), they need to have their Build Action set to "Embedded Resource". 

### Styling Your App
In Xamarin, styles can be implemented globally or locally as needed. App.xaml and MainPage.xaml show an example of global styles.

```csharp
// App.xaml
<Style x:Key="semiTransparentButton" TargetType="Button">
    <Setter Property="BackgroundColor" Value="#77000000" />
    <Setter Property="TextColor" Value="White" />
    <Setter Property="BorderRadius" Value="5" />
</Style>
```
Here the ResourceDictionary declaration sets styles for buttons with the key "semiTransparentButton". MainPage.xaml then calls that style declaration as a StaticResource.

```csharp
// MainPage.xaml
<Button Text="Introduction" Clicked="ToIntroduction" Style="{StaticResource semiTransparentButton}" />
``` 

This results in styles applied to buttons on the MainPage but also allows for the styling of any button in the same way if it is declared as a StaticResource with the key "semiTransparentButton". Consult [Xamarin Guides](https://developer.xamarin.com/guides/xamarin-forms/user-interface/styles/) for more information on styles.

## Database Connections and Customization
Mobile apps can have a range of needs in terms of accessing local and external data sources. PUMA is equipped with basic local SQLite storage.

### Local Database (SQLite)
This app comes with a simple SQLite bundle, using the [sqlite-net-pcl](https://github.com/oysteinkrog/SQLite.Net-PCL) Nuget package, that can be configured to suit the needs of your application. In App.cs the application initializes, and as soon as it does, a SQLite connection is established and put into a parent class (DBConnection) from which all repositories inherit (see code in repositories). The database is then seeded with some data related to Pumas. Note that the image references in puma_type_images refer to images bundled in the application as mentioned above in the Images section. 

Use the C# files in the Assets and Models folders to show you how to create database tables with their fields. The models define the table name and fields, and the assets files make sure a table is created and holds general purpose methods related to table.

### External Data Sources
http://www.npgsql.org/efcore/index.html
https://blog.xamarin.com/building-android-apps-with-entity-framework/


## Deployment
iOS: see [Xamarin Developer Guides](https://developer.xamarin.com/guides/ios/deployment,_testing,_and_metrics/app_distribution/app-store-distribution/publishing_to_the_app_store/)

Android: see [Xamarin Developer Guides](https://developer.xamarin.com/guides/android/deployment,_testing,_and_metrics/publishing_an_application/)