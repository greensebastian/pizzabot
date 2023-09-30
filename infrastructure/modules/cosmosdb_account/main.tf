data "azurerm_resource_group" "resource_group" {
  name = var.resource_group_name
}

locals {
  account_name = "cdba-${var.projectname}-${var.env}-${data.azurerm_resource_group.resource_group.location}"
}

resource "azurerm_cosmosdb_account" "account" {
  name                  = local.account_name
  location              = data.azurerm_resource_group.resource_group.location
  resource_group_name   = var.resource_group_name
  offer_type            = "Standard"
  kind                  = "GlobalDocumentDB"

  geo_location {
    location          = data.azurerm_resource_group.resource_group.location
    failover_priority = 0
  }

  consistency_policy {
    consistency_level = "Strong"
  }

  capabilities {
    name = "EnableServerless"
  }

  capabilities {
    name = "EnableTable"
  }
}

output "account_name" {
  value = local.account_name
}