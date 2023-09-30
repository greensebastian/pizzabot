# Build a resource group to put objects in. Used for organization
locals {
  resource_group_name = "rg_${var.projectname}_${var.env}_${var.region}"
}

resource "azurerm_resource_group" "resource_group" {
  name     = local.resource_group_name  # This is the resource_group_name value in the terrafrom backend block above above
  location = var.region
}

output "resource_group_name" {
  value = local.resource_group_name
}