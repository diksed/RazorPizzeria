window.addEventListener('DOMContentLoaded', function(event) {
  // Constants
  var DOMQUERY = {
    productSearchInput: '#productSearch-input',
    formProductItems: '.form-product-item',
    formProductName: '.form-product-name',
    formProductDescription: '.form-product-description',
    formProductExpandedOptions: '.form-product-child-label'
  };
  
  // Related DOM Contents
  var productSearchInputDOM = document.querySelector(DOMQUERY.productSearchInput);
  var productItems = document.querySelectorAll(DOMQUERY.formProductItems);

  // In memory storage for search operations
  var productStack = [];
  for(var i = 0; i<productItems.length; i++){
    var formProductNameDOM = productItems[i].querySelector(DOMQUERY.formProductName);
    var formProductDescriptionDOM = productItems[i].querySelector(DOMQUERY.formProductDescription);
    
    
    // Expanded Options
    let formProductExpandedOptionsDOM;
    if (typeof productItems[i].querySelector(DOMQUERY.formProductExpandedOptions) !== 'undefined') {
      formProductExpandedOptionsDOM = productItems[i].querySelectorAll(DOMQUERY.formProductExpandedOptions);
    }
  
    // Expanded option set
    let subProductExpandedOptions = [];
    let subProductExpandedOptionsStyle = [];
    if (typeof formProductExpandedOptionsDOM !== 'undefined' && formProductExpandedOptionsDOM.length > 0) {
      formProductExpandedOptionsDOM.forEach(function(element) {
        if (element.className.indexOf('price') === -1) {
          var optionLabel = element.innerText.toLowerCase().replace(/\s/g,'');
          optionLabel = optionLabel.replace(/[^a-zA-Z ]/g,"");
          subProductExpandedOptions.push(optionLabel);
          element.classList.add('subProduct-'+optionLabel);
        }
      });
    }


    var tempProduct = {
      DOM: productItems[i],
      name: formProductNameDOM ? formProductNameDOM.innerText : null,
      description: formProductDescriptionDOM ? formProductDescriptionDOM.innerText : null,
      subProduct: subProductExpandedOptions
    };

    productStack.push(tempProduct);
  }

  // Event Listeners
  productSearchInputDOM.addEventListener('input',
    function handleProductSearchInput(productStack, event) {
      var searchInputValue = event.target.value.trim();

      if (searchInputValue === '') {
        searchInputValue = null;
      } else {
        searchInputValue = searchInputValue.toLowerCase();
      }

      for(var i = 0; i<productStack.length; i++) {
        var product = productStack[i];
        
        // Searching From Product Name
        if(searchInputValue === null) {
          product.DOM.classList.remove('not-found');
  
          product.subProduct.forEach((value, index) => {
              var subProductClass = '.subProduct-' + value;
              if (product.DOM.querySelector(subProductClass)) {
                product.DOM.querySelector(subProductClass).parentNode.parentNode.classList.remove('search-subproduct-selection-hightlight');
              }
          });

        }
        else if (
            (searchInputValue && product.name && product.name.toLowerCase().indexOf(searchInputValue) > -1) ||
            (searchInputValue && product.description && product.description.toLowerCase().indexOf(searchInputValue) > -1)
        ) {
          product.DOM.classList.remove('not-found');
        } else {
          product.DOM.classList.add('not-found');
        }
        
        
        if (searchInputValue && product.subProduct.length > 0) {

          product.subProduct.forEach((value, index) => {
            var subProductClass = '.subProduct-' + value;
            if (value.indexOf(searchInputValue) > -1) {
              product.DOM.classList.remove('not-found');
              product.DOM.querySelector('.form-product-item-detail').style = 'height:auto';
              if (product.DOM.querySelector('.form-product-child-table')) {
                product.DOM.querySelector('.form-product-child-table').classList.add('search-subproduct-selection-show');
                // product.DOM.querySelector('.form-special-subtotal').classList.add('search-subproduct-selection-show');
              }
              
              if (product.DOM.querySelector(subProductClass)) {
                product.DOM.querySelector(subProductClass).parentNode.parentNode.classList.add('search-subproduct-selection-hightlight');
              }
            } else {
              product.DOM.querySelector(subProductClass).parentNode.parentNode.classList.remove('search-subproduct-selection-hightlight');
            }

          });
        }
      }

  }.bind(null, productStack));

  productSearchInputDOM.addEventListener('keydown', function (e) {
    if(e.keyCode === 13) {
      e.preventDefault();
    }
  });
});
