<?php
/**
 * @var \App\View\AppView $this
 * @var \App\Model\Entity\Rollballranking $rollballranking
 */
?>
<nav class="large-3 medium-4 columns" id="actions-sidebar">
    <ul class="side-nav">
        <li class="heading"><?= __('Actions') ?></li>
        <li><?= $this->Html->link(__('Edit Rollballranking'), ['action' => 'edit', $rollballranking->Rank]) ?> </li>
        <li><?= $this->Form->postLink(__('Delete Rollballranking'), ['action' => 'delete', $rollballranking->Rank], ['confirm' => __('Are you sure you want to delete # {0}?', $rollballranking->Rank)]) ?> </li>
        <li><?= $this->Html->link(__('List Rollballranking'), ['action' => 'index']) ?> </li>
        <li><?= $this->Html->link(__('New Rollballranking'), ['action' => 'add']) ?> </li>
    </ul>
</nav>
<div class="rollballranking view large-9 medium-8 columns content">
    <h3><?= h($rollballranking->Rank) ?></h3>
    <table class="vertical-table">
        <tr>
            <th scope="row"><?= __('Name') ?></th>
            <td><?= h($rollballranking->Name) ?></td>
        </tr>
        <tr>
            <th scope="row"><?= __('Time') ?></th>
            <td><?= h($rollballranking->Time) ?></td>
        </tr>
        <tr>
            <th scope="row"><?= __('Rank') ?></th>
            <td><?= $this->Number->format($rollballranking->Rank) ?></td>
        </tr>
    </table>
</div>
