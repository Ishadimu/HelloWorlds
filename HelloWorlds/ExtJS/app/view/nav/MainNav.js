Ext.define('HelloWorlds.view.nav.MainNav', {
    extend: 'Ext.container.Container',
    xtype: 'mainNav',

    requires: [
        'HelloWorlds.view.nav.MainNavController'
    ],

    controller: 'mainNav',

    layout: {
        type: 'hbox'
    },

    defaults: {
        layout: {
            type: 'hbox'
        }
    },

    items: [
        {
            xtype: 'container',
            flex: 0.5,
            items: [
                {
                    html: 'Hello, Worlds!'
                }
            ]
        },
        {
            xtype: 'container',
            flex: 0.5,
            layout: {
                type: 'hbox',
                pack: 'end'
            },
            defaults: {
                cls: ''
            },
            items: [
                {
                    xtype: 'button',
                    text: 'Universes'
                },
                {
                    xtype: 'button',
                    text: 'Worlds'
                },
                {
                    xtype: 'button',
                    text: 'Countries'
                }
            ]
        }
    ]
});