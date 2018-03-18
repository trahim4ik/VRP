webpackJsonp(["home.module"],{

/***/ "../../../../../src/app/home/home-page/home-page.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"bgimg-1\">\n  <div class=\"caption\">\n    <span class=\"border\">SCROLL DOWN</span>\n  </div>\n</div>\n\n<header class=\"header\" id=\"sticky-header\">\n  <h2>My Header</h2>\n  <button routerLink=\"/login\">Login</button>\n</header>\n\n<div style=\"color: #777;background-color:white;text-align:center;padding:50px 80px;text-align: justify;\">\n  <h3 style=\"text-align:center;\">Parallax Demo</h3>\n  <p>Parallax scrolling is a web site trend where the background content is moved at a different speed than the foreground content\n    while scrolling. Nascetur per nec posuere turpis, lectus nec libero turpis nunc at, sed posuere mollis ullamcorper libero\n    ante lectus, blandit pellentesque a, magna turpis est sapien duis blandit dignissim. Viverra interdum mi magna mi, morbi\n    sociis. Condimentum dui ipsum consequat morbi, curabitur aliquam pede, nullam vitae eu placerat eget et vehicula. Varius\n    quisque non molestie dolor, nunc nisl dapibus vestibulum at, sodales tincidunt mauris ullamcorper, dapibus pulvinar,\n    in in neque risus odio. Accumsan fringilla vulputate at quibusdam sociis eleifend, aenean maecenas vulputate, non id\n    vehicula lorem mattis, ratione interdum sociis ornare. Suscipit proin magna cras vel, non sit platea sit, maecenas ante\n    augue etiam maecenas, porta porttitor placerat leo.</p>\n</div>\n\n<div class=\"bgimg-2\">\n  <div class=\"caption\">\n    <span class=\"border\" style=\"background-color:transparent;font-size:25px;color: #f7f7f7;\">LESS HEIGHT</span>\n  </div>\n</div>\n\n<div style=\"position:relative;\">\n  <div style=\"color:#ddd;background-color:#282E34;text-align:center;padding:50px 80px;text-align: justify;\">\n    <p>Scroll up and down to really get the feeling of how Parallax Scrolling works.</p>\n  </div>\n</div>\n\n<div class=\"bgimg-3\">\n  <div class=\"caption\">\n    <span class=\"border\" style=\"background-color:transparent;font-size:25px;color: #f7f7f7;\">SCROLL UP</span>\n  </div>\n</div>\n\n<div style=\"position:relative;\">\n  <div style=\"color:#ddd;background-color:#282E34;text-align:center;padding:50px 80px;text-align: justify;\">\n    <p>Scroll up and down to really get the feeling of how Parallax Scrolling works.</p>\n  </div>\n</div>\n\n<div class=\"bgimg-1\">\n  <div class=\"caption\">\n    <span class=\"border\">COOL!</span>\n  </div>\n</div>"

/***/ }),

/***/ "../../../../../src/app/home/home-page/home-page.component.scss":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/home/home-page/home-page.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return HomePageComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var HomePageComponent = /** @class */ (function () {
    function HomePageComponent(elRef) {
        this.elRef = elRef;
    }
    HomePageComponent.prototype.ngOnInit = function () {
        this.header = document.getElementById('sticky-header');
        this.sticky = this.header.offsetTop;
        window.onscroll = onscroll;
    };
    HomePageComponent.prototype.onScroll = function ($event) {
        if (this.elRef.nativeElement.scrollTop >= this.sticky) {
            this.header.classList.add('sticky');
        }
        else {
            this.header.classList.remove('sticky');
        }
    };
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["HostListener"])('scroll', ['$event']),
        __metadata("design:type", Function),
        __metadata("design:paramtypes", [Event]),
        __metadata("design:returntype", void 0)
    ], HomePageComponent.prototype, "onScroll", null);
    HomePageComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-home-page',
            template: __webpack_require__("../../../../../src/app/home/home-page/home-page.component.html"),
            styles: [__webpack_require__("../../../../../src/app/home/home-page/home-page.component.scss")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_0__angular_core__["ElementRef"]])
    ], HomePageComponent);
    return HomePageComponent;
}());



/***/ }),

/***/ "../../../../../src/app/home/home-routing.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return HomeRoutingModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__home_page_home_page_component__ = __webpack_require__("../../../../../src/app/home/home-page/home-page.component.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



var routes = [{ path: '', component: __WEBPACK_IMPORTED_MODULE_2__home_page_home_page_component__["a" /* HomePageComponent */] }];
var HomeRoutingModule = /** @class */ (function () {
    function HomeRoutingModule() {
    }
    HomeRoutingModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["NgModule"])({
            imports: [__WEBPACK_IMPORTED_MODULE_1__angular_router__["RouterModule"].forChild(routes)],
            exports: [__WEBPACK_IMPORTED_MODULE_1__angular_router__["RouterModule"]]
        })
    ], HomeRoutingModule);
    return HomeRoutingModule;
}());



/***/ }),

/***/ "../../../../../src/app/home/home.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HomeModule", function() { return HomeModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_common__ = __webpack_require__("../../../common/esm5/common.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__home_routing_module__ = __webpack_require__("../../../../../src/app/home/home-routing.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__home_page_home_page_component__ = __webpack_require__("../../../../../src/app/home/home-page/home-page.component.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};




var HomeModule = /** @class */ (function () {
    function HomeModule() {
    }
    HomeModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["NgModule"])({
            imports: [
                __WEBPACK_IMPORTED_MODULE_1__angular_common__["CommonModule"],
                __WEBPACK_IMPORTED_MODULE_2__home_routing_module__["a" /* HomeRoutingModule */]
            ],
            declarations: [__WEBPACK_IMPORTED_MODULE_3__home_page_home_page_component__["a" /* HomePageComponent */]]
        })
    ], HomeModule);
    return HomeModule;
}());



/***/ })

});
//# sourceMappingURL=home.module.chunk.js.map