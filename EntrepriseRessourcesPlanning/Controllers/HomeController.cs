using EntrepriseRessourcesPlanning.Models;
using EntrepriseRessourcesPlanning.Service;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Http.Cors;


namespace EntrepriseRessourcesPlanning.Controllers
{


    public class HomeController : Controller
    {
        private readonly ContextDB _context;
        private readonly Services _services;

        //public static List<string> accesses = new List<string>();
        public HomeController()
        {
            _context = new ContextDB();
            _services = new Services();

        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)

        {

            if (Session["UserCIN"] == null)

            {

                RedirectToAction("SignIn", "Account").ExecuteResult(this.ControllerContext);

            }

        }
        public ActionResult NotFound()
        {
            return View();
        }
        public ActionResult Index()
        {
            if (Request.Cookies["AuthCookie"] == null)
            {
                return RedirectToAction("SignIn", "Account");

            }

            return View();
        }

        public ActionResult About()
        {
            if (Request.Cookies["AuthCookie"] == null)
            {
                return RedirectToAction("SignIn", "Account");

            }
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            if (Request.Cookies["AuthCookie"] == null)
            {
                return RedirectToAction("SignIn", "Account");

            }
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /*--------------------Products----------------------*/

        [HttpGet]
        public ActionResult AddProduct()
        {
            /*if (Request.Cookies["AuthCookie"] == null)
            {
                return RedirectToAction("SignIn", "Account");

            }*/
            if (Session["UserCIN"] == null)
            {
                return RedirectToAction ("SignIn", "Account");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(Session["Username"]);

                if (Session["Accesses"] != null)
                {
                    List<string> accessesUser = (List<string>)Session["Accesses"];

                  

                        if (accessesUser.Contains("AddingProducts") == false)
                        {
                            ViewData["ErrorMessage"] = "You do not have permission to add providers.";
                            // List<string> accesses = accessesUser.ToList();
                            return RedirectToAction("ErrorPage", "Home", new { errorMessage = ViewData["ErrorMessage"] });

                        }

                    

                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult AddProductMethod(Product product, HttpPostedFileBase[] photoFiles,string selectedCategory)
        {
            List<Category> categories = _context.Categories.ToList();
            List<string> categoriesNames = new List<string>();
            foreach(var cat in categories)
            {
                categoriesNames.Add(cat.CategoryName);
            }
            if (!(categoriesNames.Contains(selectedCategory))){
                Category newCategory = new Category()
                {
                    CategoryName = selectedCategory
                };
                _context.Categories.Add(newCategory);
                _context.SaveChanges();
            }
            int NumImages = 0;
            if (photoFiles != null && photoFiles.Length > 0)
            {
                NumImages = photoFiles.Length;
            }
                int companyRegistrationNumber = 1; 

                product.Category = selectedCategory;
                Company company = _context.Company.FirstOrDefault(c => c.RegistrationNumber == companyRegistrationNumber);
                product.Company = company;
                product.NumImages = NumImages;
                _context.Products.Add(product);
                _context.SaveChanges();
                int addedProductId = product.ProductID;
            string prodName = product.Name;
                _services.AddNotification(addedProductId,"Add Product", "A new Product: "+prodName+ " has been added By ", Session["Username"].ToString().ToUpper(), DateTime.Now.ToString(), "AddingProducts");
            
                //NotificationsController.AddNotification("A new Product has been added By ", Session["Username"].ToString().ToUpper(), addedProductId, DateTime.Now.ToString(), "AddingProducts");








            if (photoFiles != null && photoFiles.Length > 0)
            {
                foreach (var photoFile in photoFiles)
                {
                    if (photoFile.ContentLength > 0)
                    {
                        using (var binaryReader = new BinaryReader(photoFile.InputStream))
                        {
                            byte[] photoBytes = binaryReader.ReadBytes(photoFile.ContentLength);
                            ProdImages prodImages = new ProdImages
                            {
                                ProdImg = photoBytes,
                                ProductID = product.ProductID
                            };
                            _context.ProdImages.Add(prodImages);
                            _context.SaveChanges();
                        }
                    }
                }

            }

            return RedirectToAction("AllProductsData", "Home"); // Redirect to the home page or a different action
            
            //return View(product);
        }

        public ActionResult AllProducts()
        {
            /*if (Request.Cookies["AuthCookie"] == null)
            {
                return RedirectToAction("SignIn", "Account");

            }
            */
            if (Session["UserCIN"] == null)
            {
                return RedirectToAction("SignIn", "Account");
            }
            else
            {
                string userCin = Session["UserCIN"].ToString();
                var userDB = _context.Users.Include("Accesses").FirstOrDefault(u => u.UserCIN == userCin);
                System.Diagnostics.Debug.WriteLine(userDB.Name);
                System.Diagnostics.Debug.WriteLine(userDB.Accesses);
                System.Diagnostics.Debug.WriteLine(userDB.Username);
                List<string> RolesList = new List<string>();

                //RolesList.Add("AddingProducts");
                //RolesList.Add("ConsultingProducts");

                List<AccessClass> AccRoles = userDB.Accesses.ToList();
                foreach (var acc in AccRoles)
                {
                    RolesList.Add(acc.Acc_Role);
                }
                Session["Accesses"] = RolesList;


                if (Session["Accesses"] != null)
                {
                    List<string> accessesUser = (List<string>)Session["Accesses"];

                    if (accessesUser.Contains("ConsultingProducts") == false)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
            }
            var products = _context.Products.ToList();
            return View(products);


        }
        public ActionResult AllProductsData()
        {
            /*if (Request.Cookies["AuthCookie"] == null)
            {
                return RedirectToAction("SignIn", "Account");

            }
            */
            if (Session["UserCIN"] == null)
            {
                return RedirectToAction ("SignIn", "Account");
            }
            else
            {
                string userCin = Session["UserCIN"].ToString();
                var userDB = _context.Users.Include("Accesses").FirstOrDefault(u => u.UserCIN == userCin);
                System.Diagnostics.Debug.WriteLine(userDB.Name);
                System.Diagnostics.Debug.WriteLine(userDB.Accesses);
                System.Diagnostics.Debug.WriteLine(userDB.Username);
                List<string> RolesList = new List<string>();

                //RolesList.Add("AddingProducts");
                //RolesList.Add("ConsultingProducts");

                List<AccessClass> AccRoles = userDB.Accesses.ToList();
                foreach (var acc in AccRoles)
                {
                    RolesList.Add(acc.Acc_Role);
                }
                Session["Accesses"] = RolesList;


                if (Session["Accesses"] != null)
                {
                    List<string> accessesUser = (List<string>)Session["Accesses"];

                    if (accessesUser.Contains("ConsultingProducts") == false)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
            }
                var products = _context.Products.ToList();
                return View(products);

            
        }

        public ActionResult DeleteProduct(int ProductId)
        {
            Product product = _context.Products.FirstOrDefault(prod => prod.ProductID == ProductId);
            if (product != null)
            {
                // Delete the product from the database
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
                return RedirectToAction("AllProductsData", "Home");
        }
        public ActionResult DisplayImg(int productId,int imgIndex)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null && product.NumImages>0)
            {
                List<ProdImages> prodImages = _context.ProdImages.Where(prod => prod.ProductID == productId).ToList();
                return File(prodImages[imgIndex].ProdImg, "image/jpeg"); // Adjust the content type as per your image type
            }

            // If the product or photo is not found, you can return a default image or handle the scenario as desired.
            // For example:
            return File("~/path/to/default-image.jpg", "image/jpeg");
        }




        public ActionResult GetProductImages(int productId)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null && product.NumImages > 0)
            {
                List<ProdImages> prodImages = _context.ProdImages.Where(prod => prod.ProductID == productId).ToList();
                List<string> base64Images = new List<string>();
                foreach (var image in prodImages)
                {
                    base64Images.Add(Convert.ToBase64String(image.ProdImg));
                }
                return Json(base64Images); // Return the list of base64-encoded images as JSON
            }

            return Json(new List<string>()); // Return an empty list if no images are found
        }

        public ActionResult ProductDetails(int productId)
        {
            if (Session["UserCIN"] == null)
            {
                return RedirectToAction("SignIn", "Account");
            }
            else
            {
                var product = _context.Products.FirstOrDefault(p => p.ProductID == productId);

                return View(product);
            }
        }

        [HttpGet]
        public ActionResult GetProductDetails(int productId)
        {
            var product =_context.Products.FirstOrDefault(prod=>prod.ProductID==productId);

           
            return Json(product, JsonRequestBehavior.AllowGet);
        }
/////////////////////////////////////The Following Action is being replaced//////////////////////////////////////
        [HttpPost]
        public ActionResult AddPhotoToProd(int productID, HttpPostedFileBase[] photoFiles)
        {
            Product product = _context.Products.FirstOrDefault(prod => prod.ProductID == productID);

            if (ModelState.IsValid)
            {
                if (photoFiles != null && photoFiles.Length > 0)
                {
                    foreach (var photoFile in photoFiles)
                    {
                        if (photoFile.ContentLength > 0)
                        {
                            using (var binaryReader = new BinaryReader(photoFile.InputStream))
                            {
                                byte[] photoBytes = binaryReader.ReadBytes(photoFile.ContentLength);
                                ProdImages prodImages = new ProdImages
                                {
                                    ProdImg = photoBytes,
                                    ProductID = productID
                                };
                                _context.ProdImages.Add(prodImages);
                                _context.SaveChanges();
                            }
                            product.NumImages += 1;
                            _context.SaveChanges();

                        }
                    }

                }
            }

            return RedirectToAction("AllProductsData", "Home");
        }
        
        public ActionResult EditProduct(int productId)
        {
            Product product = _context.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }
        public ActionResult UpdateProduct(Product model, HttpPostedFileBase[] photoFiles)
        {
            if (ModelState.IsValid)
            {
                // Find the existing product in the database
                Product existingProduct = _context.Products.FirstOrDefault(p => p.ProductID == model.ProductID);

                if (existingProduct != null)
                {
                    // Update the properties of the existing product with the new values from the model
                    existingProduct.Name = model.Name;
                    existingProduct.Description = model.Description;
                    existingProduct.Category = model.Category;
                    existingProduct.Stock = model.Stock;
                    existingProduct.UnitPrice = model.UnitPrice;
                    existingProduct.DiscountPrice = model.DiscountPrice;

                    if (photoFiles != null && photoFiles.Length > 0)
                    {
                        foreach (var photoFile in photoFiles)
                        {
                            if (photoFile != null)
                            {
                                if (photoFile.ContentLength > 0)
                                {
                                    using (var binaryReader = new BinaryReader(photoFile.InputStream))
                                    {
                                        byte[] photoBytes = binaryReader.ReadBytes(photoFile.ContentLength);
                                        ProdImages prodImages = new ProdImages
                                        {
                                            ProdImg = photoBytes,
                                            ProductID = model.ProductID
                                        };
                                        _context.ProdImages.Add(prodImages);
                                        _context.SaveChanges();
                                    }
                                    existingProduct.NumImages += 1;

                                }
                            }
                        }

                    }
                    _context.SaveChanges();
                    int updatedProductId = existingProduct.ProductID;
                    string ProdName = existingProduct.Name;
                    _services.AddNotification(updatedProductId,"Update Product", ProdName+" Product has been updated By ", Session["Username"].ToString().ToUpper(), DateTime.Now.ToString(), "AddingProducts");
                }
            }
                           
            return RedirectToAction("ProductDetails", new { productId = model.ProductID });
        }

        /*--------------------Providers----------------------*/

        public ActionResult AddProvider()
        {
            /*if (Request.Cookies["AuthCookie"] == null)
            {
                return RedirectToAction("SignIn", "Account");

            }*/
            if (Session["UserCIN"] == null)
            {
                return RedirectToAction("SignIn", "Account");
            }
            else
            {
                List<string> accessesUser = (List<string>)Session["Accesses"];

                if (accessesUser.Contains("AddingProviders") == false)
                {
                    ViewData["ErrorMessage"] = "You do not have permission to add providers.";
                    // List<string> accesses = accessesUser.ToList();
                    return RedirectToAction("ErrorPage", "Home", new { errorMessage = ViewData["ErrorMessage"] });

                }

            }
            return View();
        }
        public ActionResult AddProviderMethod(Provider provider)
        {
            if (ModelState.IsValid)
            {
                _context.Providers.Add(provider);
                _context.SaveChanges();

                return RedirectToAction("ProvidersList", "Home"); // Redirect to the home page or a different action
            }
            return View(provider);
        }

        public ActionResult ProvidersList()
        {
            /*if (Request.Cookies["AuthCookie"] == null)
            {
                return RedirectToAction("SignIn", "Account");

            }*/
            if (Session["UserCIN"] == null)
            {
                return RedirectToAction("SignIn", "Account");
            }
            else
            {
                List<string> accessesUser = (List<string>)Session["Accesses"];

               

                    if (accessesUser.Contains("AddingProviders") == false)
                    {
                        ViewData["ErrorMessage"] = "You do not have permission to add providers.";
                        // List<string> accesses = accessesUser.ToList();
                        return RedirectToAction("ErrorPage", "Home", new { errorMessage = ViewData["ErrorMessage"] });

                    }

                
            }

            // Retrieve list of providers from the database
            var providers = _context.Providers.ToList();

            return View(providers);
        }
        public ActionResult DeleteProvider(int providerId)
        {
            var provider = _context.Providers.Find(providerId);

            if (provider != null)
            {
                // Delete the provider from the database
                _context.Providers.Remove(provider);
                _context.SaveChanges();

            }
            return RedirectToAction("ProvidersList");

        }

        /*--------------------Users----------------------*/

        public ActionResult AddUser()
        {
            /*if (Request.Cookies["AuthCookie"] == null)
            {
                return RedirectToAction("SignIn", "Account");

            }*/
            if (Session["UserCIN"] == null)
            {
                return RedirectToAction("SignIn", "Account");
            }
            else
            {
                List<string> accessesUser = (List<string>)Session["Accesses"];

                if (accessesUser.Contains("AddingUsers") == false)
                {
                    ViewData["ErrorMessage"] = "You do not have permission to add providers.";
                    // List<string> accesses = accessesUser.ToList();
                    return RedirectToAction("ErrorPage", "Home", new { errorMessage = ViewData["ErrorMessage"] });
                }

            }
            var accesses = _context.Accesses.ToList();
            return View(accesses);
        }
        [HttpPost]
        public ActionResult AddUserMethod(User user, string confirmPassword, string[] SelectedAccesses)
        {
            if (ModelState.IsValid)
            {
                if (user.Password != confirmPassword)
                {
                    ModelState.AddModelError("ConfirmPassword", "Passwords do not match");
                    return View("AddUser", user);
                }

                // Check if a user with the given CIN already exists
                var existingUser = _context.Users.FirstOrDefault(u => u.UserCIN == user.UserCIN);
                if (existingUser != null)
                {
                    ModelState.AddModelError("UserCIN", "A user with the given CIN already exists");
                    return View("AddUser", user);
                }
                var AccessesList = _context.Accesses.Where(acc => SelectedAccesses.Contains(acc.Acc_Role)).ToList();

                user.Accesses = AccessesList;
                
                // Add the user to the database
                _context.Users.Add(user);
                _context.SaveChanges();
                string variable = "Hello, world!";
                System.Diagnostics.Debug.WriteLine(variable);
                System.Diagnostics.Debug.WriteLine(SelectedAccesses);



                // Redirect to a success page or perform any other necessary action
                return RedirectToAction("AllProductsData", "Home");

            }
            return View(user);
        }
        public ActionResult UsersList() {
            if (Session["UserCIN"] == null)
            {
                return RedirectToAction("SignIn", "Account");
            }
            else
            {
                List<string> accessesUser = (List<string>)Session["Accesses"];

                if (accessesUser.Contains("AddingUsers") == false)
                {
                    ViewData["ErrorMessage"] = "You do not have permission to add providers.";
                    // List<string> accesses = accessesUser.ToList();
                    return RedirectToAction("ErrorPage", "Home", new { errorMessage = ViewData["ErrorMessage"] });
                }

            }

            // Retrieve list of users from the database
            var users = _context.Users.ToList();

            return View(users);
        }

        public ActionResult DeleteUser(string UserCIN)
        {
            User user = _context.Users.FirstOrDefault(u => u.UserCIN == UserCIN);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return RedirectToAction("UsersList", "Home");
        }
        /*-------------------------Error Page-------------------------*/
        public ActionResult ErrorPage(string errorMessage)
        {
            List<string> accessesUser = (List<string>)Session["Accesses"];
            ViewData["Accesses"] = accessesUser;// new List<string>  { "zzz", "zzzze" };
            ViewData["ErrorMessage"] = errorMessage;
            return View();
        }
        /*--------------------Purchase Orders----------------------*/

        public ActionResult AddPurchaseOrder()
        {
            if (Session["UserCIN"] == null)
            {
                return RedirectToAction("SignIn", "Account");
            }
            
            
                List<string> accessesUser = (List<string>)Session["Accesses"];

                if (accessesUser.Contains("AddingPurchaseOrder") == false)
                {
                    ViewData["ErrorMessage"] = "You do not have permission to add providers.";
                    // List<string> accesses = accessesUser.ToList();
                    return RedirectToAction("ErrorPage", "Home", new { errorMessage = ViewData["ErrorMessage"] });
                }
                var model = new PurchaseOrderViewModel
                {
                    PurchaseOrder = new PurchaseOrder(),
                    ProductOrders = new List<ProductOrder>(),
                    Providers = _context.Providers.ToList() // Fetch providers from the database
                };
            
            return View(model);
        }
        public ActionResult AddPurchaseOrderMethod(PurchaseOrderViewModel purchaseOrderViewModel)
        {
            Provider selectedProvider = _context.Providers.FirstOrDefault(p => p.ProviderID == purchaseOrderViewModel.PurchaseOrder.ProviderID);
            purchaseOrderViewModel.PurchaseOrder.ProviderID = selectedProvider.ProviderID;
            purchaseOrderViewModel.PurchaseOrder.Products = new List<ProductOrder>();

            foreach (var productOrder in purchaseOrderViewModel.ProductOrders)
            {
                if (!string.IsNullOrEmpty(productOrder.Name) && !string.IsNullOrEmpty(productOrder.Description) &&  productOrder.UnitPriceHT > 0 && productOrder.Quantity > 0 && productOrder.ProductID > 0)
                {
                    productOrder.TotalPriceHT = productOrder.UnitPriceHT * productOrder.Quantity;
                    productOrder.TVA = productOrder.TotalPriceHT * 0.2m;
                    productOrder.TotalTTC = productOrder.TotalPriceHT + productOrder.TVA;
                    purchaseOrderViewModel.PurchaseOrder.Products.Add(productOrder);

                }
            }

            // Calculate the total amount
            purchaseOrderViewModel.PurchaseOrder.TotalAmount = purchaseOrderViewModel.ProductOrders.Sum(p => p.TotalTTC);

            Company company = _context.Company.FirstOrDefault(c => c.RegistrationNumber == 1);
            purchaseOrderViewModel.PurchaseOrder.CompanyID = company.RegistrationNumber;

            //purchaseOrderViewModel.PurchaseOrder.TotalAmount = TotalAmount;
            if (purchaseOrderViewModel.PurchaseOrder.Products.Count > 0)
            {
                _context.PurchaseOrders.Add(purchaseOrderViewModel.PurchaseOrder);
                _context.SaveChanges();
                int addedOrderId = purchaseOrderViewModel.PurchaseOrder.OrderNum;
                
                    _services.AddNotification(addedOrderId,"Add Purchase Order", "A new Purchase Order has been added By ", Session["Username"].ToString().ToUpper(), DateTime.Now.ToString(), "AddingPurchaseOrder");
                
            }
            return RedirectToAction("AddPurchaseOrder", "Home");
        }
        


        public ActionResult PurchaseDetails(int OrderNum)
        {
            PurchaseOrder purchaseOrderDetails = _context.PurchaseOrders.Include("Products").FirstOrDefault(p => p.OrderNum == OrderNum);
            List<ProductOrder> productsOrder = purchaseOrderDetails.Products;

            return View(productsOrder);
        }
        public ActionResult PurchaseDetailsModifier(int OrderNum)
        {
            PurchaseOrder purchaseOrderDetails = _context.PurchaseOrders.Include("Products").FirstOrDefault(p => p.OrderNum == OrderNum);
            List<ProductOrder> productsOrder = purchaseOrderDetails.Products;

            return View(productsOrder);
        }

        [HttpPost]
        public ActionResult UpdatePurchaseProductOrder(int ProductOrderID, int Quantity)
        {
            // Get the product order from the database
            var purchaseOrder = _context.PurchaseOrders
                .Include("Products")
                .FirstOrDefault(po => po.Products.Any(p => p.ID == ProductOrderID));

            if (purchaseOrder != null)
            {
                // Update the quantity and calculate the new total price, TVA, and total TTC
                var productOrder = purchaseOrder.Products.FirstOrDefault(po => po.ID == ProductOrderID);
                productOrder.Quantity = Quantity;
                productOrder.TotalPriceHT = productOrder.UnitPriceHT * Quantity;
                productOrder.TVA = productOrder.TotalPriceHT * 0.2m;
                productOrder.TotalTTC = productOrder.TotalPriceHT + productOrder.TVA;

                // Update the total amount for the corresponding purchase order
                purchaseOrder.TotalAmount = purchaseOrder.Products.Sum(po => po.TotalTTC);

                // Save the changes to the database
                _context.SaveChanges();
            }

            // Redirect back to the AddReceipt action to refresh the view
            return RedirectToAction("AllPurchaseOrders", "Home");
        }

        public ActionResult AllPurchaseOrders()
        {
            if (Session["UserCIN"] == null)
            {
                return RedirectToAction("SignIn", "Account");
            }
            else
            {
                
                    List<string> accessesUser = (List<string>)Session["Accesses"];

                    if (accessesUser.Contains("AddingPurchaseOrder") == false)
                    {
                        ViewData["ErrorMessage"] = "You do not have permission to add providers.";
                        // List<string> accesses = accessesUser.ToList();
                        return RedirectToAction("ErrorPage", "Home", new { errorMessage = ViewData["ErrorMessage"] });

                    }

                
                AllPurchaseViewModel allPurchaseViewModel = new AllPurchaseViewModel();
                List<PurchaseOrder> purchaseOrders = _context.PurchaseOrders.Where(po => po.ReceiptID == 0).ToList();
                List<Provider> providers = _context.Providers.ToList();
                allPurchaseViewModel.PurchaseOrders = purchaseOrders;
                allPurchaseViewModel.Providers = providers;
                return View(allPurchaseViewModel);
            }
        }
        public ActionResult DeletePurchaseOrder(int OrderNum)
        {

            List<ProductOrder> productOrders = _context.ProductOrders.Where(po => po.Purchase.OrderNum == OrderNum).ToList();
            foreach (var productOrder in productOrders)
            {
                _context.ProductOrders.Remove(productOrder);
                _context.SaveChanges();
            }
            PurchaseOrder purchaseOrder = _context.PurchaseOrders.FirstOrDefault(po => po.OrderNum == OrderNum);
            if (purchaseOrder != null)
            {
                // Delete the provider from the database
                _context.PurchaseOrders.Remove(purchaseOrder);
                _context.SaveChanges();
            }
            return RedirectToAction("AllPurchaseOrders", "Home");
        }
        public ActionResult DeleteProductOrder(int ProductOrderID)
        {
            ProductOrder productOrder = _context.ProductOrders.Include("Purchase").FirstOrDefault(po => po.ID == ProductOrderID);
            int purchaseOrderNum = productOrder.Purchase.OrderNum;
            PurchaseOrder purchaseOrder = _context.PurchaseOrders.Include("Products").FirstOrDefault(po => po.OrderNum == purchaseOrderNum);
            _context.ProductOrders.Remove(productOrder);
            _context.SaveChanges();
            if (purchaseOrder.Products.Count == 0)
            {
                _context.PurchaseOrders.Remove(purchaseOrder);
                _context.SaveChanges();
                return RedirectToAction("AllPurchaseOrders", "Home");

            }
            else
            {
                purchaseOrder.TotalAmount = purchaseOrder.Products.Sum(po => po.TotalTTC);
                _context.SaveChanges();
            }
            return RedirectToAction("PurchaseDetailsModifier", "Home", new { OrderNum = purchaseOrder.OrderNum });
        }

        /*--------------------Receipts----------------------*/

        public ActionResult AddReceipt()
        {
            if (Session["UserCIN"] == null)
            {
                return RedirectToAction("SignIn", "Account");
            }
            else
            {
                
                
                    List<string> accessesUser = (List<string>)Session["Accesses"];

                    if (accessesUser.Contains("AddingReceipt") == false)
                    {
                        ViewData["ErrorMessage"] = "You do not have permission to add providers.";
                        // List<string> accesses = accessesUser.ToList();
                        return RedirectToAction("ErrorPage", "Home", new { errorMessage = ViewData["ErrorMessage"] });

                    }

                
                var model = new ReceiptViewModel();

                // Populate the Providers and other necessary data in the model
                model.Providers = _context.Providers.ToList();

                model.PurchaseOrders = _context.PurchaseOrders.Where(po => !(po.ReceiptID != 0)).ToList();
                return View(model);
            }
        }

        public ActionResult AddReceiptMethod(ReceiptViewModel ReceiptViewModel)
        {
            if (ReceiptViewModel.Receipt.ProviderID != 0)
            {

                //int[] selectedPurchaseOrders = ReceiptViewModel.SelectedPurchaseOrderIDs;
                Receipt Receipt = new Receipt();
                Receipt.ReceptionDate = ReceiptViewModel.Receipt.ReceptionDate;

                Company company = _context.Company.FirstOrDefault(c => c.RegistrationNumber == 1);
                Receipt.CompanyID = company.RegistrationNumber;

                Receipt.TotalAmount = ReceiptViewModel.TotalAmount;

                Provider provider = _context.Providers.FirstOrDefault(p => p.ProviderID == ReceiptViewModel.Receipt.ProviderID);
                Receipt.ProviderID = provider.ProviderID;

                List<PurchaseOrder> selectedOrders = new List<PurchaseOrder>();
                /* List<int> SelectedPurchaseOrders = ReceiptViewModel.SelectedPurchaseOrderIDs;*/

                List<int> SelectedPurchaseOrders = ReceiptViewModel.SelectedPurchaseOrderIDs;
                foreach (int orderNum in SelectedPurchaseOrders)
                {
                    PurchaseOrder purchaseOrder = _context.PurchaseOrders.FirstOrDefault(p => p.OrderNum == orderNum);
                    if (purchaseOrder != null)
                    {
                        selectedOrders.Add(purchaseOrder);
                    }
                }
                Receipt.PurchaseOrdersIDs = SelectedPurchaseOrders;
                decimal totalAmount = 0;
                foreach (var purchaseOrder in selectedOrders)
                {
                    totalAmount += purchaseOrder.TotalAmount;
                }
                Receipt.TotalAmount = totalAmount;
                _context.Receipts.Add(Receipt);
                _context.SaveChanges();
                int addedReceiptId = Receipt.ReceiptID;
                //NotificationsController.AddNotification("A new Receipt has been added By ", Session["Username"].ToString().ToUpper(), addedReceiptId, DateTime.Now.ToString(), "AddingReceipt");

                    _services.AddNotification(addedReceiptId,"Add Receipt", "A new Receipt has been added By ", Session["Username"].ToString().ToUpper(), DateTime.Now.ToString(), "AddingReceipt");
            

                Receipt receipt = _context.Receipts.OrderByDescending(r => r.ReceiptID).FirstOrDefault();
                int ReceiptID = receipt.ReceiptID;
                List<int> PurchaseOrdersInReceipt = receipt.PurchaseOrdersIDs.ToList();
                
                List<Product> products = _context.Products.ToList();

                List<int> productIDs = new List<int>();
                

                foreach(var prod in products)
                {
                    productIDs.Add(prod.ProductID);
                }



                foreach(int purchaseOrderID in PurchaseOrdersInReceipt)
                {
                    PurchaseOrder purchaseOrder = _context.PurchaseOrders.Include("Products").FirstOrDefault(po => po.OrderNum == purchaseOrderID);


                    foreach(var productOrder in purchaseOrder.Products)
                    {
                        if (productIDs.Contains(productOrder.ProductID))
                        {
                            Product product = _context.Products.FirstOrDefault(p => p.ProductID == productOrder.ProductID);
                            product.Stock += productOrder.Quantity;
                            _context.SaveChanges();

                        }
                        else
                        
                        {
                            Product product = new Product();
                            product.Name = productOrder.Name;
                            product.Description = productOrder.Description;
                            product.Category = productOrder.Category;
                            product.Stock = productOrder.Quantity;
                            product.UnitPrice = productOrder.UnitPriceHT;
                            product.Company = company;
                            _context.Products.Add(product);
                            _context.SaveChanges();

                        }
                    }


                    purchaseOrder.ReceiptID = ReceiptID;
                }
                _context.SaveChanges();

                return RedirectToAction("AddReceipt", "Home");
            }
            return RedirectToAction("AddReceipt", "Home");

        }

        public ActionResult ReceiptDetails(int ReceiptID)
        {
            List<PurchaseOrder> purchaseOrders = _context.PurchaseOrders.Where(po => po.ReceiptID == ReceiptID).ToList();

            return View(purchaseOrders);
        }

        public ActionResult AllReceipts()
        {
            if (Session["UserCIN"] == null)
            {
                return RedirectToAction("SignIn", "Account");
            }
            else
            {
                
                
                    List<string> accessesUser = (List<string>)Session["Accesses"];

                    if (accessesUser.Contains("AddingReceipt") == false)
                    {
                        ViewData["ErrorMessage"] = "You do not have permission to add providers.";
                        // List<string> accesses = accessesUser.ToList();
                        return RedirectToAction("ErrorPage", "Home", new { errorMessage = ViewData["ErrorMessage"] });

                    }

                
                AllReceiptsViewModel allReceiptsViewModel = new AllReceiptsViewModel();
                List<Receipt> receipts = _context.Receipts.Where(po => po.InvoiceID == 0).ToList();
                List<Provider> providers = _context.Providers.ToList();
                allReceiptsViewModel.Receipts = receipts;
                allReceiptsViewModel.Providers = providers;
                return View(allReceiptsViewModel);
            }
        }
        public ActionResult DeleteReceipt(int ReceiptID)
        {
            List<PurchaseOrder> purchaseOrdersInReceipt = _context.PurchaseOrders.Where(po => po.ReceiptID == ReceiptID).ToList();
            foreach(PurchaseOrder po in purchaseOrdersInReceipt)
            {
                po.ReceiptID = 0;
                _context.SaveChanges();

            }
            Receipt receipt = _context.Receipts.FirstOrDefault(rec => rec.ReceiptID == ReceiptID);
            _context.Receipts.Remove(receipt);
            _context.SaveChanges();
            return RedirectToAction("AllReceipts","Home");
        }

        public ActionResult ReceiptDetailsModifier(int ReceiptID)
        {
            List<PurchaseOrder> purchaseOrdersInReceipt = _context.PurchaseOrders.Where(po => po.ReceiptID == ReceiptID).ToList();

            return View(purchaseOrdersInReceipt);
        }
        public ActionResult DeletePurchaseOrderFromReceipt(int OrderNum)
        {
            PurchaseOrder purchaseOrder = _context.PurchaseOrders.FirstOrDefault(po => po.OrderNum == OrderNum);
            int ReceiptID = purchaseOrder.ReceiptID;
            purchaseOrder.ReceiptID = 0;
            _context.SaveChanges();
            List<PurchaseOrder> purchaseOrders = _context.PurchaseOrders.Where(po => po.ReceiptID == ReceiptID).ToList();
            if (purchaseOrders.Count > 0)
            {
                return RedirectToAction("ReceiptDetailsModifier", "Home", new { ReceiptID = ReceiptID });
            }
            else
            {
                Receipt receipt = _context.Receipts.FirstOrDefault(rec => rec.ReceiptID == ReceiptID);
                _context.Receipts.Remove(receipt);
                _context.SaveChanges();
                return RedirectToAction("AllReceipts", "Home");
            }
        }
        /*--------------------Invoices----------------------*/

        public ActionResult AddInvoice()
        {
            if (Session["UserCIN"] == null)
            {
                return RedirectToAction("SignIn", "Account");
            }
            else
            {
              
                    List<string> accessesUser = (List<string>)Session["Accesses"];

                    if (accessesUser.Contains("AddingInvoice") == false)
                    {
                        ViewData["ErrorMessage"] = "You do not have permission to add providers.";
                        // List<string> accesses = accessesUser.ToList();
                        return RedirectToAction("ErrorPage", "Home", new { errorMessage = ViewData["ErrorMessage"] });

                    }

                
                var model = new InvoiceViewModel();
                model.Providers = _context.Providers.ToList();
                model.Receipts = _context.Receipts.Where(rec => !(rec.InvoiceID != 0)).ToList();

                return View(model);
            }
        }

        public ActionResult AddInvoiceMethod(InvoiceViewModel InvoiceViewModel)
        {
            Invoice Invoice = new Invoice();
            Company company = _context.Company.FirstOrDefault(c => c.RegistrationNumber == 1);
            Invoice.CompanyID = company.RegistrationNumber;
            Invoice.InvoiceDate = InvoiceViewModel.Invoice.InvoiceDate;
            Invoice.ExpirationDate = InvoiceViewModel.Invoice.ExpirationDate;
            Invoice.PaymentMethod = InvoiceViewModel.Invoice.PaymentMethod;
            Provider provider = _context.Providers.FirstOrDefault(pro => pro.ProviderID == InvoiceViewModel.Invoice.ProviderID);
            Invoice.ProviderID = provider.ProviderID;
            //Invoice.Receipts = InvoiceViewModel.Invoice.Receipts;

            List<Receipt> receipts = new List<Receipt>();
            List<int> SelectedReceipts= InvoiceViewModel.SelectedReceiptsIDs;
            foreach (int receiptID in SelectedReceipts)
            {
                Receipt receipt = _context.Receipts.FirstOrDefault(r => r.ReceiptID == receiptID);
                if (receipt != null)
                {
                    receipts.Add(receipt);
                }
            }
            Invoice.ReceiptsIDs = SelectedReceipts;

            decimal totalAmount = 0;
            foreach (var receipt in receipts)
            {
                totalAmount += receipt.TotalAmount;
            }
            Invoice.TotalAmount = totalAmount;

            _context.Invoices.Add(Invoice);
            _context.SaveChanges();
            int addedInvoiceId = InvoiceViewModel.Invoice.InvoiceID;

            //NotificationsController.AddNotification("A new Invoice has been added By ", Session["Username"].ToString().ToUpper(), addedInvoiceId, DateTime.Now.ToString(), "AddingInvoice");
            
                _services.AddNotification(addedInvoiceId,"Add Invoice", "A new Invoice has been added By ", Session["Username"].ToString().ToUpper(), DateTime.Now.ToString(), "AddingInvoice");
            

            Invoice invoice = _context.Invoices.OrderByDescending(inv=>inv.InvoiceID).FirstOrDefault();
            int InvoiceID = invoice.InvoiceID;
            List<int> ReceiptsIDs = invoice.ReceiptsIDs.ToList();
            foreach (int receiptID in ReceiptsIDs)
            {
                Receipt receipt = _context.Receipts.FirstOrDefault(r => r.ReceiptID == receiptID);
                receipt.InvoiceID = InvoiceID;
                _context.SaveChanges();
            }
            return RedirectToAction("AddInvoice", "Home");

        }
        public ActionResult AllInvoices()
        {
            if (Session["UserCIN"] == null)
            {
                return RedirectToAction("SignIn", "Account");
            }
            else
            {
                
                    List<string> accessesUser = (List<string>)Session["Accesses"];

                    if (accessesUser.Contains("AddingInvoice") == false)
                    {
                        ViewData["ErrorMessage"] = "You do not have permission to add providers.";
                        // List<string> accesses = accessesUser.ToList();
                        return RedirectToAction("ErrorPage", "Home", new { errorMessage = ViewData["ErrorMessage"] });

                    }

                

                AllInvoicesViewModel allInvoicesViewModel = new AllInvoicesViewModel();
                List<Invoice> invoices = _context.Invoices.ToList();
                List<Provider> providers = _context.Providers.ToList();
                allInvoicesViewModel.Invoices = invoices;
                allInvoicesViewModel.Providers = providers;
                return View(allInvoicesViewModel);
            }
        }

        public ActionResult DeleteInvoice(int InvoiceID)
        {
            List<Receipt> receiptsInInvoice = _context.Receipts.Where(rec => rec.InvoiceID == InvoiceID).ToList();
            foreach (Receipt rec in receiptsInInvoice)
            {
                rec.InvoiceID = 0;
                _context.SaveChanges();

            }
            Invoice invoice = _context.Invoices.FirstOrDefault(inv => inv.InvoiceID == InvoiceID);
            _context.Invoices.Remove(invoice);
            _context.SaveChanges();
            return RedirectToAction("AllInvoices", "Home");
        }

        public ActionResult InvoiceDetailsModifier(int InvoiceID)
        {
            List<Receipt> receiptsInInvoice = _context.Receipts.Where(rec => rec.InvoiceID == InvoiceID).ToList();

            return View(receiptsInInvoice);
        }

        public ActionResult DeleteReceiptFromInvoice(int ReceiptID)
        {
            Receipt receipt = _context.Receipts.FirstOrDefault(rec => rec.ReceiptID == ReceiptID);
            int InvoiceID = receipt.InvoiceID;
            receipt.InvoiceID = 0;
            _context.SaveChanges();
            List<Receipt> receipts = _context.Receipts.Where(rec => rec.InvoiceID == InvoiceID).ToList();
            if (receipts.Count > 0)
            {
                return RedirectToAction("InvoiceDetailsModifier", "Home", new { InvoiceID = InvoiceID });
            }
            else
            {
                Invoice invoice = _context.Invoices.FirstOrDefault(inv => inv.InvoiceID == InvoiceID);
                _context.Invoices.Remove(invoice);
                _context.SaveChanges();
                return RedirectToAction("AllInvoices", "Home");
            }
        }








        public ActionResult TestNavigation()
        {
            return View();
        }
        public ActionResult TableTest()
        {
            return View();
        }






    }
}
