<?php
/**
 * @var \App\View\AppView $this
 * @var \App\Model\Entity\Rollballranking $rollballranking
 */
?>
<nav class="large-3 medium-4 columns" id="actions-sidebar">
    <ul class="side-nav">
        <li class="heading"><?= __('Actions') ?></li>
        <li><?= $this->Html->link(__('List Rollballranking'), ['action' => 'index']) ?></li>
    </ul>
</nav>
<div class="rollballranking form large-9 medium-8 columns content">
    <?= $this->Form->create($rollballranking) ?>
    <fieldset>
        <legend><?= __('Add Rollballranking') ?></legend>
        <?php
            echo $this->Form->control('Name');
            echo $this->Form->control('Time');
        ?>
    </fieldset>
    <?= $this->Form->button(__('Submit')) ?>
    <?= $this->Form->end() ?>
</div>