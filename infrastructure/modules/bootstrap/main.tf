# Build a resource group to put objects in. Used for organization
resource "azurerm_resource_group" "resource_group" {
  name     = "rg_${var.projectname}_terraform"  # This is the resource_group_name value in the terrafrom backend block above above
  location = var.region
}

resource "azurerm_storage_account" "storage_account" {
  # Name can only consist of lowercase letters and numbers, and must be between 3 and 24 characters long
  name                      = "${var.projectname}terraform"  # This is the storage_account_name value in the terraform backend block above
  resource_group_name       = azurerm_resource_group.resource_group.name
  location                  = azurerm_resource_group.resource_group.location
  account_tier              = "Standard"
  account_kind              = "StorageV2"
  account_replication_type  = "LRS"
  enable_https_traffic_only = true
}

resource "azurerm_storage_container" "storage_container" {
  # Name must be lower-case characters or numbers only. No hyphens, underscores, or caps.
  name                 = "${var.projectname}-terraform"  ## This is the container_name value in the terraform backend block above above
  storage_account_name = azurerm_storage_account.storage_account.name
}