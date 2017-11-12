Ext.define('HelloWorlds.view.nav.MainNav', {
    extend: 'Ext.container.Container',
    xtype: 'mainNav',

    requires: [
        'HelloWorlds.view.nav.MainNavController'
    ],

    controller: 'mainNav',

    viewModel: {
        formulas: {
            getHelloWorldDisplayText: {
                get: function () {
                    var pathName = window.location.pathname;                    
                    if (pathName.replace(/\//g, '') === 'extjs')
                        return '';

                    return '';
                }
            }
        }
    },

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
            flex: 0.33,
            items: [
                {
                    bind: {
                        html: '{getHelloWorldDisplayText}'
                    }
                }
            ]
        },
        {
            xtype: 'container',
            layout: {
                type: 'hbox',
                pack: 'center'
            },
            // flex: 0.33,
            items: [
                {
                    xtype: 'button',
                    tooltip: 'Project Home Page',
                    tooltipType: 'title',
                    glyph: 'xf015@FontAwesome',
                    cls: ['btn', 'icon'],
                    handler: function() {
                        window.location = "http://helloworlds.ishadimu.com";
                    }
                }
            ]
        },
        {
            xtype: 'container',
            flex: 0.33,
            layout: {
                type: 'hbox',
                pack: 'end'
            },
            defaults: {
                cls: ['btn']
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