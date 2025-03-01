package at.sampas.personal_share.file.domain;

import at.sampas.personal_share.user.FileOwnerId;

import java.util.List;

public record FileOwnerState(FileOwnerId fileOwnerId, List<StoredFile> files) {}
