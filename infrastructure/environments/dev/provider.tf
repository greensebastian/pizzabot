# Establish the baseline version for AzureRM provider or newer
provider "azurerm" {
  features {}
}

# Establish terraform baseline version or newer
# Also tell terraform to use a remote backend to store to and fetch from for state file storage
terraform {
  required_version = ">=1.5.7"
  backend "azurerm" {
    resource_group_name  = "rg_pizzabot_terraform"
    storage_account_name = "pizzabotterraform"
    container_name       = "pizzabot-terraform"
    key                  = "pizzabot-bootstrap-dev.tfstate"
  }
}