# PDFtoAriaPlugin

A plugin script that uses Oncology Services and Eclipse Scripting APIs to upload a PDF file into Aria.

An Oncology Services API key is available at my.varian.com.  The API key must be uploaded into the Varian Service Portal.  If running on a test box, Aria must have the Oncology Services package installed (must be able to access Documents workspace).  Must also edit the PDFtoAria.setting file values to be site specific (e.g. rename HostName to "tbox15", Port to "55051", enter DocKey value, and ImportDir to "\\\tbox15\va_data$\PDFTemp").  Keep the comma placement to help with the regex match.  Once an esapi.dll is created, it can be ran as a plugin script.

Works with multiple pdf files and will combine them before uploading.

Uses code contributed by Matt Schmidt (https://github.com/mattcschmidt) and work from WUSTL (https://github.com/WUSTL-ClinicalDev).  Also references work in the my.Varian webinar from 23-3-2020 (https://github.com/VarianAPIs/Varian-Code-Samples).  Many thanks for your help!

