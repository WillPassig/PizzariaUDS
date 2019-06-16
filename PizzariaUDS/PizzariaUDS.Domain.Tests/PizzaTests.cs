using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzariaUDS.Domain.Models;
using PizzariaUDS.Domain.Models.Pizzas;
using System.Collections.Generic;

namespace PizzariaUDS.Domain.Tests
{
    [TestClass]
    public class PizzaTests
    {
        [TestMethod]
        public void Pizza_CalculatePriceAndEstimatedTime_Small_Calabresa()
        {
            int smallPizzaPrice = 20;
            int calabresaPrice = 0;

            int smallPizzaEstimatedPreparationTime = 15;
            int calabresaEstimatedPreparationTime = 0;

            int expectedPizzaPrice = smallPizzaPrice + calabresaPrice;
            int expectedPizzaEstimatedPreparationTime = smallPizzaEstimatedPreparationTime + calabresaEstimatedPreparationTime;
            int expectedAmountOfCustomizations = 0;

            Pizza pizza = new Pizza(Models.Pizzas.PizzaSize.SMALL, Models.Pizzas.PizzaFlavor.CALABRESA);

            pizza.Price.Should().Be(expectedPizzaPrice);
            pizza.EstimatedPreparationTime.Should().Be(expectedPizzaEstimatedPreparationTime);
            pizza.Customizations.Count.Should().Be(expectedAmountOfCustomizations);
        }

        [TestMethod]
        public void Pizza_CalculatePriceAndEstimatedTime_Medium_Marguerita()
        {
            int mediumPizzaPrice = 30;
            int margueritaPrice = 0;

            int mediumPizzaEstimatedPreparationTime = 20;
            int margueritaEstimatedPreparationTime = 0;

            int expectedPizzaPrice = mediumPizzaPrice + margueritaPrice;
            int expectedPizzaEstimatedPreparationTime = mediumPizzaEstimatedPreparationTime + margueritaEstimatedPreparationTime;
            int expectedAmountOfCustomizations = 0;

            Pizza pizza = new Pizza(Models.Pizzas.PizzaSize.MEDIUM, Models.Pizzas.PizzaFlavor.MARGUERITA);

            pizza.Price.Should().Be(expectedPizzaPrice);
            pizza.EstimatedPreparationTime.Should().Be(expectedPizzaEstimatedPreparationTime);
            pizza.Customizations.Count.Should().Be(expectedAmountOfCustomizations);
        }

        [TestMethod]
        public void Pizza_CalculatePriceAndEstimatedTime_Large_Portuguesa()
        {
            int largePizzaPrice = 40;
            int portuguesaPrice = 0;

            int largePizzaEstimatedPreparationTime = 25;
            int portuguesaEstimatedPreparationTime = 5;

            int expectedPizzaPrice = largePizzaPrice + portuguesaPrice;
            int expectedPizzaEstimatedPreparationTime = largePizzaEstimatedPreparationTime + portuguesaEstimatedPreparationTime;
            int expectedAmountOfCustomizations = 0;

            Pizza pizza = new Pizza(Models.Pizzas.PizzaSize.LARGE, Models.Pizzas.PizzaFlavor.PORTUGUESA);

            pizza.Price.Should().Be(expectedPizzaPrice);
            pizza.EstimatedPreparationTime.Should().Be(expectedPizzaEstimatedPreparationTime);
            pizza.Customizations.Count.Should().Be(expectedAmountOfCustomizations);
        }

        [TestMethod]
        public void Pizza_CalculatePriceAndEstimatedTime_Medium_Marguerita_ExtraBacon()
        {
            int mediumPizzaPrice = 30;
            int margueritaPrice = 0;
            int extraBaconPrice = 3;

            int mediumPizzaEstimatedPreparationTime = 20;
            int margueritaEstimatedPreparationTime = 0;
            int extraBaconEstimatedPreparationTime = 0;

            int expectedAmountOfCustomizations = 1;

            int expectedPizzaPrice = mediumPizzaPrice + margueritaPrice + extraBaconPrice;
            int expectedPizzaEstimatedPreparationTime = mediumPizzaEstimatedPreparationTime + margueritaEstimatedPreparationTime + extraBaconEstimatedPreparationTime;

            List<PizzaCustomization> customizations = new List<PizzaCustomization>();
            customizations.Add(PizzaCustomization.EXTRA_BACON);

            Pizza pizza = new Pizza(Models.Pizzas.PizzaSize.MEDIUM, Models.Pizzas.PizzaFlavor.MARGUERITA, customizations);

            pizza.Price.Should().Be(expectedPizzaPrice);
            pizza.EstimatedPreparationTime.Should().Be(expectedPizzaEstimatedPreparationTime);
            pizza.Customizations.Count.Should().Be(expectedAmountOfCustomizations);
        }

        [TestMethod]
        public void Pizza_CalculatePriceAndEstimatedTime_Medium_Marguerita_NoOnions()
        {
            int mediumPizzaPrice = 30;
            int margueritaPrice = 0;
            int noOnionsPrice = 0;

            int mediumPizzaEstimatedPreparationTime = 20;
            int margueritaEstimatedPreparationTime = 0;
            int noOnionsEstimatedPreparationTime = 0;

            int expectedAmountOfCustomizations = 1;

            int expectedPizzaPrice = mediumPizzaPrice + margueritaPrice + noOnionsPrice;
            int expectedPizzaEstimatedPreparationTime = mediumPizzaEstimatedPreparationTime + margueritaEstimatedPreparationTime + noOnionsEstimatedPreparationTime;

            List<PizzaCustomization> customizations = new List<PizzaCustomization>();
            customizations.Add(PizzaCustomization.NO_ONIONS);

            Pizza pizza = new Pizza(Models.Pizzas.PizzaSize.MEDIUM, Models.Pizzas.PizzaFlavor.MARGUERITA, customizations);

            pizza.Price.Should().Be(expectedPizzaPrice);
            pizza.EstimatedPreparationTime.Should().Be(expectedPizzaEstimatedPreparationTime);
            pizza.Customizations.Count.Should().Be(expectedAmountOfCustomizations);
        }

        [TestMethod]
        public void Pizza_CalculatePriceAndEstimatedTime_Medium_Marguerita_StuffedCrust()
        {
            int mediumPizzaPrice = 30;
            int margueritaPrice = 0;
            int stuffedCrustPrice = 5;

            int mediumPizzaEstimatedPreparationTime = 20;
            int margueritaEstimatedPreparationTime = 0;
            int stuffedCrustEstimatedPreparationTime = 5;

            int expectedAmountOfCustomizations = 1;

            int expectedPizzaPrice = mediumPizzaPrice + margueritaPrice + stuffedCrustPrice;
            int expectedPizzaEstimatedPreparationTime = mediumPizzaEstimatedPreparationTime + margueritaEstimatedPreparationTime + stuffedCrustEstimatedPreparationTime;

            List<PizzaCustomization> customizations = new List<PizzaCustomization>();
            customizations.Add(PizzaCustomization.STUFFED_CRUST);

            Pizza pizza = new Pizza(Models.Pizzas.PizzaSize.MEDIUM, Models.Pizzas.PizzaFlavor.MARGUERITA, customizations);

            pizza.Price.Should().Be(expectedPizzaPrice);
            pizza.EstimatedPreparationTime.Should().Be(expectedPizzaEstimatedPreparationTime);
            pizza.Customizations.Count.Should().Be(expectedAmountOfCustomizations);
        }

        [TestMethod]
        public void Pizza_CalculatePriceAndEstimatedTime_Large_Portuguesa_AllCustomizations()
        {
            int largePizzaPrice = 40;
            int portuguesaPrice = 0;
            int extraBaconPrice = 3;
            int noOnionsPrice = 0;
            int stuffedCrustPrice = 5;

            int largePizzaEstimatedPreparationTime = 25;
            int portuguesaEstimatedPreparationTime = 5;
            int extraBaconEstimatedPreparationTime = 0;
            int noOnionsEstimatedPreparationTime = 0;
            int stuffedCrustEstimatedPreparationTime = 5;

            int expectedAmountOfCustomizations = 3;

            int expectedPizzaPrice = largePizzaPrice + portuguesaPrice
                + extraBaconPrice + noOnionsPrice + stuffedCrustPrice;

            int expectedPizzaEstimatedPreparationTime = largePizzaEstimatedPreparationTime + portuguesaEstimatedPreparationTime
                + extraBaconEstimatedPreparationTime + noOnionsEstimatedPreparationTime + stuffedCrustEstimatedPreparationTime;

            List<PizzaCustomization> customizations = new List<PizzaCustomization>();
            customizations.Add(PizzaCustomization.EXTRA_BACON);
            customizations.Add(PizzaCustomization.NO_ONIONS);
            customizations.Add(PizzaCustomization.STUFFED_CRUST);

            Pizza pizza = new Pizza(Models.Pizzas.PizzaSize.LARGE, Models.Pizzas.PizzaFlavor.PORTUGUESA, customizations);

            pizza.Price.Should().Be(expectedPizzaPrice);
            pizza.EstimatedPreparationTime.Should().Be(expectedPizzaEstimatedPreparationTime);
            pizza.Customizations.Count.Should().Be(expectedAmountOfCustomizations);
        }
    }
}
