<?php
/**
 * @var \App\View\AppView $this
 * @var \App\Model\Entity\Rollballranking[]|\Cake\Collection\CollectionInterface $rollballranking
 */
?>
<nav class="large-3 medium-4 columns" id="actions-sidebar">
    <ul class="side-nav">
        <li class="heading"><?= __('Actions') ?></li>
        <li><?= $this->Html->link(__('New Rollballranking'), ['action' => 'add']) ?></li>
    </ul>
</nav>
<div class="rollballranking index large-9 medium-8 columns content">
    <h3><?= __('Rollballranking') ?></h3>
    <table cellpadding="0" cellspacing="0">
        <thead>
            <tr>
                <th scope="col"><?= $this->Paginator->sort('Rank') ?></th>
                <th scope="col"><?= $this->Paginator->sort('Name') ?></th>
                <th scope="col"><?= $this->Paginator->sort('Time') ?></th>
                <th scope="col" class="actions"><?= __('Actions') ?></th>
            </tr>
        </thead>
        <tbody>
            <?php foreach ($rollballranking as $rollballranking): ?>
            <tr>
                <td><?= $this->Number->format($rollballranking->Rank) ?></td>
                <td><?= h($rollballranking->Name) ?></td>
                <td><?= h($rollballranking->Time) ?></td>
                <td class="actions">
                    <?= $this->Html->link(__('View'), ['action' => 'view', $rollballranking->Rank]) ?>
                    <?= $this->Html->link(__('Edit'), ['action' => 'edit', $rollballranking->Rank]) ?>
                    <?= $this->Form->postLink(__('Delete'), ['action' => 'delete', $rollballranking->Rank], ['confirm' => __('Are you sure you want to delete # {0}?', $rollballranking->Rank)]) ?>
                </td>
            </tr>
            <?php endforeach; ?>
        </tbody>
    </table>
    <div class="paginator">
        <ul class="pagination">
            <?= $this->Paginator->first('<< ' . __('first')) ?>
            <?= $this->Paginator->prev('< ' . __('previous')) ?>
            <?= $this->Paginator->numbers() ?>
            <?= $this->Paginator->next(__('next') . ' >') ?>
            <?= $this->Paginator->last(__('last') . ' >>') ?>
        </ul>
        <p><?= $this->Paginator->counter(['format' => __('Page {{page}} of {{pages}}, showing {{current}} record(s) out of {{count}} total')]) ?></p>
    </div>
</div>
