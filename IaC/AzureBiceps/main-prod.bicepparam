using 'main.bicep'

param storageAccountName = 'stgmyappprod001'
param location = 'eastus'
param storageSku = 'Premium_LRS'

param tags = {
  Environment: 'prod'
  Project: 'AzureBicepsDemo'
}

