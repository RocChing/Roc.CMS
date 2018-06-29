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

        function deleteCategory(model) {
            abp.message.confirm(
                app.localize('Pages.Contents.Category.Delete.WarningMessage', model.name),
                app.localize('AreYouSure'),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _categoryService.deleteCategory(model.id).done(function () {
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

        $('#ParentId').selectpicker({
            iconBase: "fa",
            tickIcon: "fa fa-check"
        });

        $('#btnSearch,#RefreshButton').click(function (e) {
            e.preventDefault();
            reload();
        });

        $('#txtFilter').on('keydown', function (e) {
            if (e.keyCode !== 13) {
                return;
            }
            e.preventDefault();
            reload();
        });

        abp.event.on('app.createOrEditCategoryModalSaved', function () {
            reload();
        });

        var dataTable = _categroyTable.DataTable({
            paging: true,
            serverSide: true,
            processing: true,
            listAction: {
                ajaxFunction: _categoryService.getCategories,
                inputFilter: function () {
                    return {
                        filter: $('#txtFilter').val(),
                        parentId: $('#ParentId').val()
                    };
                }
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
                        enabled: function (data) {
                            return data.record.parentId > 0;
                        },
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
                                    deleteCategory(data.record);
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
                    data: "target",
                    render: function (target) {
                        var s = '';
                        switch (target) {
                            case 1:
                                s = "_Blank(新开页面)";
                                break;
                            case 2:
                                s = "Self(本页面)";
                                break;
                        }
                        return s;
                    }
                },
                {
                    targets: 5,
                    data: "isNav",
                    render: function (isNav) {
                        return getYesNoHtml(isNav);
                    }
                },
                {
                    targets: 6,
                    data: "isSpecial",
                    render: function (isSpecial) {
                        return getYesNoHtml(isSpecial);
                    }
                }
            ]
        });

        function getYesNoHtml(flag) {
            var $span = $("<span/>").addClass("label");
            if (flag) {
                $span.addClass("m-badge m-badge--success m-badge--wide").text(app.localize('Yes'));
            } else {
                $span.addClass("m-badge m-badge--metal m-badge--wide").text(app.localize('No'));
            }
            return $span[0].outerHTML;
        }

        function reload() {
            dataTable.ajax.reload();
        }
    });
})();