/**
 * System configuration for Angular samples
 * Adjust as necessary for your application needs.
 */
(function (global) {
    System.config({
        paths: {
            // paths serve as alias
            'npm:': 'node_modules/'
        },
        // map tells the System loader where to look for things
        map: {
            // our app is within the app folder
            "app": 'app',
            "public-app": "public-app",

            // custom modules            
            'core-module': 'core-module',

            // angular bundles
            '@angular/core': 'npm:@angular/core/bundles/core.umd.js',
            '@angular/common': 'npm:@angular/common/bundles/common.umd.js',
            '@angular/compiler': 'npm:@angular/compiler/bundles/compiler.umd.js',
            '@angular/platform-browser': 'npm:@angular/platform-browser/bundles/platform-browser.umd.js',
            '@angular/platform-browser-dynamic': 'npm:@angular/platform-browser-dynamic/bundles/platform-browser-dynamic.umd.js',
            '@angular/http': 'npm:@angular/http/bundles/http.umd.js',
            '@angular/router': 'npm:@angular/router/bundles/router.umd.js',
            '@angular/forms': 'npm:@angular/forms/bundles/forms.umd.js',
            '@angular/platform-browser/animations' : 'npm:@angular/platform-browser/bundles/platform-browser-animations.umd.js',
            '@angular/animations': 'npm:@angular/animations/bundles/animations.umd.js',
            '@angular/animations/browser': 'npm:@angular/animations/bundles/animations-browser.umd.js',

            // other libraries
            'rxjs': 'npm:rxjs',
            'ng2-bs3-modal': 'node_modules/ng2-bs3-modal',
            'angular-in-memory-web-api': 'npm:angular-in-memory-web-api',
            '@ng-bootstrap/ng-bootstrap': 'node_modules/@ng-bootstrap/ng-bootstrap/bundles/ng-bootstrap.js',
            'angular2-logger': 'node_modules/angular2-logger',
            'ng2-translate': 'node_modules/ng2-translate/bundles',
            'ng2-cookies': 'node_modules/ng2-cookies',
            'ng2-select': 'node_modules/ng2-select',
            'moment': 'node_modules/moment',
            'mydatepicker': 'node_modules/mydatepicker/bundles/mydatepicker.umd.js'
        },
        // packages tells the System loader how to load when no filename and/or no extension
        packages: {
            "app": {
                main: './main.js',
                defaultExtension: 'js'
            },
            'public-app': {
                main: './main.js',
                defaultExtension: 'js'
            },            
            'core-module': {
                defaultExtension: 'js'
            },            
            rxjs: {
                defaultExtension: 'js'
            },
            'angular-in-memory-web-api': {
                main: './index.js',
                defaultExtension: 'js'
            },
            'angular2-logger': { defaultExtension: 'js' },
            'ng2-translate': {
                main: 'index.js',
                defaultExtension: 'js',
                format: 'cjs'
            },
            'ng2-bs3-modal': {
                main: 'ng2-bs3-modal.js',
                defaultExtension: 'js'
            },
            'ng2-cookies': {
                main: 'ng2-cookies.js',
                defaultExtension: 'js'
            },
            'ng2-select': {
                main: 'index.js',
                defaultExtension: 'js'
            },           
            'moment': {
                main: 'moment.js',
                defaultExtension: 'js'
            }
        }
    });
})(this);