# Build a resource group to put objects in. Used for organization
resource "azurerm_resource_group" "resource_group" {
  name     = "rg_${var.projectname}_${var.env}_${var.region}"  # This is the resource_group_name value in the terrafrom backend block above above
  location = var.region
}