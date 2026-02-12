using 'main.bicep'

param storageAccountName = 'stgmyappdev001'
param location = 'eastus'
param storageSku = 'Standard_LRS'

param tags = {
  Environment: 'dev'
  Project: 'AzureBicepsDevDemo'
}

