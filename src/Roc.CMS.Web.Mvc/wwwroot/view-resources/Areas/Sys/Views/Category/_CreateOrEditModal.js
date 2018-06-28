(function () {
    app.modals.CreateOrEditCategoryModal = function () {
        var _modalManager, $form;
        var _categoryService = abp.services.app.category;

        this.init = function (modalManager) {
            _modalManager = modalManager;
            var $modal = _modalManager.getModal();
            $form = $modal.find('form[name="CategoryForm"]');

            $modal.find('#ParentId').selectpicker({
                iconBase: "fa",
                tickIcon: "fa fa-check"
            });
        }

        this.save = function () {
            if (!$form.valid()) {
                return;
            }
            var category = $form.serializeFormToObject();

            _modalManager.setBusy(true);
            _categoryService.createOrUpdateCategory(category).done(function () {
                abp.notify.info(app.localize('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('app.createOrEditCategoryModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        }
    }
})();
