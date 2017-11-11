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

    style: {
        margin: 'auto',
        backgroundColor: 'white'
    },

    items: [
        {
            xtype: 'subNav'            
        },
        {
            xtype: 'mainNav'
        },
        {
            xtype: 'textfield',
            title: 'Home',
            iconCls: 'fa-home'
            // The following grid shares a store with the classic version's grid as well!
        }, {
            xtype: 'textfield',
            title: 'Users',
            iconCls: 'fa-user'
        }, {
            xtype: 'textfield',
            title: 'Groups',
            iconCls: 'fa-users'
        }, {
            xtype: 'textfield',
            title: 'Settings',
            iconCls: 'fa-cog'
        },
        {
            xtype: 'footer'
        }
    ]
});
