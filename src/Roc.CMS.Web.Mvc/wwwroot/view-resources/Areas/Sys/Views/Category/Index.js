(function () {
    $(function () {

        var _categroyTable = $('#CategoryTable');
        var _categoryService = abp.services.app.category;

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Contents.Category.Create'),
            edit: abp.auth.hasPermission('Pages.Contents.Category.Edit'),
            'delete': abp.auth.hasPermission('Pages.Contents.Category.Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Sys/Category/CreateOrEditModal',
            scriptUrl: abp.appPath + 'view-resources/Areas/Sys/Views/Category/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditCategoryModal'
        });

        function deleteEdition(edition) {
            abp.message.confirm(
                app.localize('EditionDeleteWarningMessage', edition.displayName),
                app.localize('AreYouSure'),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _categoryService.deleteEdition({
                            id: edition.id
                        }).done(function () {
                            reload();
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                    }
                }
            );
        };

        $('#CreateNewCategoryBtn').click(function () {
            _createOrEditModal.open();
        });

        abp.event.on('app.createOrEditCategoryModalSaved', function () {
            reload();
        });

        var dataTable = _categroyTable.DataTable({
            paging: false,
            listAction: {
                ajaxFunction: _categoryService.getCategories
            },
            columnDefs: [
                {
                    targets: 0,
                    data: null,
                    orderable: false,
                    autoWidth: false,
                    defaultContent: '',
                    rowAction: {
                        text: '<i class="fa fa-cog"></i> ' + app.localize('Actions') + ' <span class="caret"></span>',
                        items: [
                            {
                                text: app.localize('Edit'),
                                visible: function () {
                                    return _permissions.edit;
                                },
                                action: function (data) {
                                    _createOrEditModal.open({ id: data.record.id });
                                }
                            }, {
                                text: app.localize('Delete'),
                                visible: function () {
                                    return _permissions.delete;
                                },
                                action: function (data) {
                                    deleteEdition(data.record);
                                }
                            }
                        ]
                    }
                },
                {
                    targets: 1,
                    data: "name"
                },
                {
                    targets: 2,
                    data: "parentName"
                },
                {
                    targets: 3,
                    data: "url"
                },
                {
                    targets: 4,
                    data: "target"
                },
                {
                    targets: 5,
                    data: "isNav"
                },
                {
                    targets: 6,
                    data: "isSpecial"
                }
            ]
        });

        function reload() {
            dataTable.ajax.reload();
        }
    });
})();