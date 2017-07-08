# NopCommand

NopCommand  is a command line tool for NopCommerce.

  - Command line to use services of NopCommerce.
  - Generic Data Query for IRepotory Interface.
  - Code generator for most service interface.

# Compile

  - Create a Tool directory under nop commerce src directory
  - Copy NopCommand project to tool directory.

# Database configuration
  Copy Settings.txt from Nop.Web's App_Data directory.

# Binary
  unzip Exe.zip ,copy Settings.txt of your nopcommerce site. The binary was built with NopCommerce 3.9,which means
  it works with 3.9 version. If you want to support other version, use the source to build for the NopCommerce version.
  
# Command Line

### Generic data query
 Type ReadTable [TableName] [Id] [top]
 for example.
```sh
ReadTable Category 1
```

it returns Category with id =1, if id=-1, return all categories
```json
[                                                 
  {                                               
    "Name": "Computers",                          
    "Description": null,                          
    "CategoryTemplateId": 1,                      
    "MetaKeywords": null,                         
    "MetaDescription": null,                      
    "MetaTitle": null,                            
    "ParentCategoryId": 0,                        
    "PictureId": 1,                               
    "PageSize": 6,                                
    "AllowCustomersToSelectPageSize": true,       
    "PageSizeOptions": "6, 3, 9",                 
    "PriceRanges": null,                          
    "ShowOnHomePage": false,                      
    "IncludeInTopMenu": true,                     
    "SubjectToAcl": false,                        
    "LimitedToStores": false,                     
    "Published": true,                            
    "Deleted": false,                             
    "DisplayOrder": 1,                            
    "CreatedOnUtc": "2017-06-28T12:06:31.143",    
    "UpdatedOnUtc": "2017-06-28T12:06:31.143",    
    "AppliedDiscounts": [],                       
    "Id": 1                                       
  }                                               
]                                                 
```
### Help [CommandName]
```sh
opCommand> Help
```
it returns all the commands current supported in NopCommand
```json
[
  "AclCommands",
  "AddressAttributeCommands",
  "AddressCommands",
  "AffiliateCommands",
  "BackInStockSubscriptionCommands",
  "BlogCommands",
  "CampaignCommands",
  "CategoryCommands",
  "CategoryTemplateCommands",
  "CheckoutAttributeCommands",
  "CountryCommands",
  "CurrencyCommands",
  "CustomerActivityCommands",
  "CustomerAttributeCommands",
  "CustomerCommands",
  "CustomerRegistrationCommands",
  "CustomerReportCommands",
  "DataCommands",
  "DateRangeCommands",
  "DiscountCommands",
  "DownloadCommands",
  "EmailAccountCommands",
  "EncryptionCommands",
  "ForumCommands",
  "GenericAttributeCommands",
  "GeoLookupCommands",
  "GiftCardCommands",
  "LanguageCommands",
  "LocalizedEntityCommands",
  "ManufacturerCommands",
  "ManufacturerTemplateCommands",
  "MeasureCommands",
  "MessageTemplateCommands",
  "NewsCommands",
  "NewsLetterSubscriptionCommands",
  "OpenAuthenticationCommands",
  "OrderCommands",
  "OrderReportCommands",
  "OrderTotalCalculationCommands",
  "PaymentCommands",
  "PermissionCommands",
  "PictureCommands",
  "PollCommands",
  "ProductAttributeCommands",
  "ProductCommands",
  "ProductTagCommands",
  "ProductTemplateCommands",
  "QueuedEmailCommands",
  "RecentlyViewedProductsCommands",
  "ReturnRequestCommands",
  "RewardPointCommands",
  "ScheduleTaskCommands",
  "SearchTermCommands",
  "SettingCommands",
  "ShipmentCommands",
  "ShippingCommands",
  "ShoppingCartCommands",
  "SpecificationAttributeCommands",
  "StateProvinceCommands",
  "StoreCommands",
  "StoreMappingCommands",
  "TaxCategoryCommands",
  "TaxCommands",
  "TopicCommands",
  "TopicTemplateCommands",
  "UrlRecordCommands",
  "VendorCommands",
  "WorkflowMessageCommands"
]
```
These commands mostly relate to Service interface defined in Nop.Services
i.e  TaxCommands -->ITaxService etc.
```sh
Help TopicCommands
```
returns all the sub commands for given command group
```json
[                           
  "GetTopicById",           
  "GetTopicBySystemName",   
  "GetAllTopics"            
]                           
```
For simplicity and safety purpose, only read command for each Service interface currently supported in NopCommand
### Command Code Generator
For most of the service interface defined in Nop.Services, There are about 4 different return types:
  -IPagedList<T>
  -IList<T>
  -T
  -Primitive or String

To save the time of copy and paste, NopCommand has a class named CommandCodeGenerator
this class uses C# reflection to generate over 90% of code for above commands.
four code template are defined
```C#
/// <summary>
        /// The template type0
        /// </summary>
        public const string TemplateType0 =
            TabSpace + TabSpace + TabSpace + "var [SERVICEVARIABLE] = EngineContext.Current.Resolve<[SERVICEINTERFACE]>();\r\n" +
            TabSpace + TabSpace + TabSpace + "var [SERVICECOREVARIABLE] = [METHODNAME];\r\n" +
            TabSpace + TabSpace + TabSpace + "var [VARIABLE] = AutoMapperConfiguration.Mapper.Map<[DESTINATIONTYPE]>([SERVICECOREVARIABLE]);\r\n" +
            TabSpace + TabSpace + TabSpace + "return JsonConvert.SerializeObject([VARIABLE], Formatting.Indented);";

        /// <summary>
        /// The template type1
        /// </summary>
        public const string TemplateType1 =
                TabSpace + TabSpace + TabSpace + "var [SERVICEVARIABLE] = EngineContext.Current.Resolve<[SERVICEINTERFACE]>();\r\n" +
                TabSpace + TabSpace + TabSpace + "var [SERVICECOREVARIABLE] = [METHODNAME];\r\n" +
                TabSpace + TabSpace + TabSpace + "var [VARIABLE] = [SERVICECOREVARIABLE].MapSourcePageList<[SOURCETYPE], [DESTINATIONTYPE]> (AutoMapperConfiguration.Mapper);\r\n" +
                TabSpace + TabSpace + TabSpace + "return JsonConvert.SerializeObject([VARIABLE], Formatting.Indented, new PageListConverter<[DESTINATIONTYPE]>());"
            ;

        /// <summary>
        /// The template type2
        /// </summary>
        public const string TemplateType2 =
            TabSpace + TabSpace + TabSpace + "var [SERVICEVARIABLE] = EngineContext.Current.Resolve<[SERVICEINTERFACE]>();\r\n" +
            TabSpace + TabSpace + TabSpace + "var [SERVICECOREVARIABLE] = [METHODNAME];\r\n" +
            TabSpace + TabSpace + TabSpace + "var [VARIABLE] = [SERVICECOREVARIABLE].MapSource<[SOURCETYPE], [DESTINATIONTYPE]>(AutoMapperConfiguration.Mapper);\r\n" +
            TabSpace + TabSpace + TabSpace + "return JsonConvert.SerializeObject([VARIABLE], Formatting.Indented);";

        /// <summary>
        /// The template type3
        /// </summary>
        public const string TemplateType3 =
            TabSpace + TabSpace + TabSpace + "var [SERVICEVARIABLE] = EngineContext.Current.Resolve<[SERVICEINTERFACE]>();\r\n" +
            TabSpace + TabSpace + TabSpace + "var [SERVICECOREVARIABLE] = [METHODNAME];\r\n" +
            TabSpace + TabSpace + TabSpace + "return JsonConvert.SerializeObject([SERVICECOREVARIABLE], Formatting.Indented);";
```

You can extend this class to support other service methods to generate all the command code.


# Command Framework
  The command framework uses ConsoleApplicationBase at https://github.com/TypecastException/ConsoleApplicationBase
