/**
 * This class is the main view for the application. It is specified in app.js as the
 * "mainView" property. That setting automatically applies the "viewport"
 * plugin causing this view to become the body element (i.e., the viewport).
 *
 * TODO - Replace this content of this view to suite the needs of your application.
 */
Ext.define('HelloWorlds.view.main.Main', {
    extend: 'Ext.container.Container',
    xtype: 'app-main',

    requires: [
        'HelloWorlds.view.main.MainController',
        'HelloWorlds.view.main.MainModel',
        'HelloWorlds.view.nav.SubNav',
        'HelloWorlds.view.nav.SubNavController',
        'HelloWorlds.view.nav.MainNav',
        'HelloWorlds.view.nav.MainNavController',
        'HelloWorlds.view.nav.Footer',
        'HelloWorlds.view.nav.FooterController'
    ],

    controller: 'main',
    viewModel: 'main',

    width: 1200,
    height: '100%',
    scrollable: true,

    style: {
        margin: 'auto',
        backgroundImage: 'url(resources/images/earth.jpg)',
        backgroundSize: 'cover'
    },

    items: [
        {
            xtype: 'subNav'
        },
        {
            xtype: 'mainNav'
        },
        {
            id: 'front-content',
            html: '<h1>Hello, Worlds!</h1>',
            style: {
                padding: '200px 0 200px 0'
            }
        }, 
        {
            xtype: 'container'
        }, 
        {
            xtype: 'footer'
        }
    ]
});
