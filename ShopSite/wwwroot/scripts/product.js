
const addToCart = (product) => {


    var oldCart = JSON.parse(localStorage.getItem('cart'));//arr of products
    if (oldCart == null) localStorage.setItem('cart', JSON.stringify([{ ...product, 'count': 1 }]))
    else {
        var oldProduct = oldCart.find(item => item.productId == product.productId);
        if (oldProduct) {
            oldProduct.count = parseInt(oldProduct.count) + 1;
        }
        else {
            oldCart = [...oldCart, { ...product, 'count': 1 }]
        }
        localStorage.setItem('cart', JSON.stringify(oldCart))

    }
    counterCartProducts();
}



const drowProducts = (products) => {
    const template = document.getElementsByTagName("template")[0];

    products.forEach(product => {
        var clone = template.content.cloneNode(true);
        clone.querySelector(".card h1").innerText = `${product.name}`;
        clone.querySelector(".img-w img").src = `../images/${product.image}`;
        clone.querySelector(".price").innerText = `${product.price} ₪`;
        clone.querySelector(".description").innerText = `${product.description}`;
        clone.querySelector(".card button").addEventListener("click", () => addToCart(product))

        document.getElementById("ProductList").appendChild(clone);

    } )
    
       

}


const loadProducts = async (queryParamsUrl = '') => {
    cleanScreen()
    var products;
    console.log(`api/products${queryParamsUrl}`)
    const response = await fetch(`api/products${queryParamsUrl}`);
    if (response.status == 200) {
        products = await response.json();

        drowProducts(products);
    }

}

const drowCategories = (categories) => {
    const template = document.getElementsByTagName("template")[1];

    categories.forEach(category => {
        var clone = template.content.cloneNode(true);
        clone.querySelector(".OptionName").innerText = `${category.name}`;
        clone.querySelector(".opt").id = `${category.categoryId}`;
        clone.querySelector(".opt").addEventListener('click', filterProducts);

        document.getElementById("categoryList").appendChild(clone);

    })
}

const loadCategories = async () => {
    var categories;
    const response = await fetch(`api/categories`);
    if (response.status == 200) {
        categories = await response.json();

        drowCategories(categories);


    }


}

const filterProducts = () => {
    var name = document.getElementById('nameSearch').value;
    name ? name = `name=${name}`: name=''
    var minPrice = document.getElementById('minPrice').value;
    minPrice ? minPrice = `minPrice=${minPrice}` : minPrice=''
    var maxPrice = document.getElementById('maxPrice').value;
    maxPrice ? maxPrice = `maxPrice=${maxPrice}` : maxPrice = ''

    const categoriesId = Array.from(document.getElementsByClassName("opt")).filter(category => category.checked).map(category => `categoriesId=${category.id}&`).join('') || '';
    const queryParamsUrl = `?${categoriesId}${name}${minPrice}${maxPrice}`
    loadProducts(queryParamsUrl);
}

function cleanScreen() {
    document.getElementById('ProductList').innerText=''
}

const counterCartProducts = () => {
    var oldCart = JSON.parse(localStorage.getItem('cart'));//arr of products
    const counter = oldCart.reduce((sum, product) => { return sum + product.count }, 0)
    document.getElementById('ItemsCountText').innerText = counter; 
}

function loadPage() {

    window.addEventListener("load", (e)=>loadProducts());
    window.addEventListener("load", loadCategories);
    window.addEventListener("load",counterCartProducts)
}


loadPage()


